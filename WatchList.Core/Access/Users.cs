using AutoMapper;
using WatchList.Core.Access.Interfaces;
using WatchList.Core.Constants;
using WatchList.Core.Data.Entities.Enums;
using WatchList.Core.Data.Entities;
using WatchList.Core.Data.Repositories.Interfaces;
using WatchList.Core.Exceptions;
using WatchList.Core.Helpers;
using WatchList.Core.Models.Requests;
using WatchList.Core.Models.Responses;
using WatchList.Core.Models;
using WatchList.Core.Services.Interfaces;
using WatchList.Core.Utils;
using Azure.Core;

namespace WatchList.Core.Access
{
    public class Users : IUsers
    {
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IEmailService _emailService;


        private readonly IUserTokenRepository _userTokenRepository;
        private readonly IUserPromptRepository _userPromptRepository;
        private readonly IUserRepository _userRepository;

        public Users(ITokenService tokenService, IEmailService emailService, IUserRepository userRepository,
            IUserPromptRepository userPromptRepository, IUserTokenRepository userTokenRepository, IMapper mapper)
        {
            _tokenService = tokenService;
            _emailService = emailService;
            _mapper = mapper;

            _userRepository = userRepository;
            _userPromptRepository = userPromptRepository;
            _userTokenRepository = userTokenRepository;
        }

        public async Task<AuthenticateResponse> AuthenticateAsync(AuthenticateRequest? request)
        {
            if (request == null)
            {
                throw new HttpBadRequestException("Request is null");
            }
            
            if (string.IsNullOrEmpty(request.EmailAddress) || string.IsNullOrEmpty(request.Password))
            {
                throw new HttpBadRequestException("Email Address or password not supplied");
            }

            if (!Validations.IsValidEmailAddress(request.EmailAddress))
            {
                throw new HttpBadRequestException("Email Address isn't valid");
            }

            var dbUser = await _userRepository.GetByEmailAddress(request.EmailAddress);
            if (dbUser == null)
            {
                throw new HttpUnauthorizedException("Invalid Email Address / Password");
            }

            if (dbUser.PasswordAttempts >= AuthenticationConstants.MaxPasswordAttempts)
            {
                await IncrementPasswordAttempt(dbUser, true);
                throw new HttpUnauthorizedException("Invalid Email Address / Password");
            }

            if (!Cryptography.VerifyHash(request.Password, dbUser.Password, dbUser.PasswordSalt))
            {
                await IncrementPasswordAttempt(dbUser);
                throw new HttpUnauthorizedException("Invalid Email Address / Password");
            }

            if (!dbUser.CanSignIn(out var message))
            {
                throw new HttpUnauthorizedException(message);
            }

            dbUser.PasswordAttempts = 0;
            await _userRepository.Update(dbUser);

            var user = _mapper.Map<User>(dbUser);

            try
            {
                var newTokenId = Guid.NewGuid();
                var bearerToken = _tokenService.BuildToken(user, newTokenId);
                var refreshToken = _tokenService.BuildRefreshToken(user, newTokenId);

                await _userTokenRepository.Add(new DbUserToken()
                {
                    Id = newTokenId,
                    User = dbUser
                });

                return new AuthenticateResponse(bearerToken, refreshToken);
            }
            catch (TokenGenerationException e)
            {
                throw new HttpInternalServerErrorException(e.Message);
            }

        }

        private async Task IncrementPasswordAttempt(DbUser dbUser, bool lockUser = false)
        {
            Random r = new Random();
            var range = (1.0 + dbUser.PasswordAttempts * 0.1) * 1000;
            Thread.Sleep(Convert.ToInt32(r.NextDouble() * range));

            if (lockUser)
            {
                dbUser.Status = DbUserStatusTypeEnum.Locked;
            }

            dbUser.PasswordAttempts++;
            await _userRepository.Update(dbUser);
        }

        public async Task<ReauthenticateResponse> ReauthenticateAsync(ReauthenticateRequest? request)
        {
            if (request == null)
            {
                throw new HttpBadRequestException("Request is null");
            }

            if (string.IsNullOrEmpty(request.RefreshToken))
            {
                throw new HttpBadRequestException("Refresh Token not supplied");
            }

            var userId = _tokenService.DecryptRefreshToken(request.RefreshToken, out Guid previousTokenId);

            var dbUser = await _userRepository.GetById(userId);
            if (dbUser == null)
            {
                throw new HttpUnauthorizedException("Invalid User");
            }

            var userToken = await _userTokenRepository.GetValidUserToken(userId, previousTokenId);
            if (userToken == null)
            {
                throw new HttpUnauthorizedException("Token invalid");
            }

            var user = _mapper.Map<User>(dbUser);

            try
            {
                var newTokenId = Guid.NewGuid();

                var bearerToken = _tokenService.BuildToken(user, newTokenId);
                var refreshToken = _tokenService.BuildRefreshToken(user, newTokenId);

                await _userTokenRepository.Add(new DbUserToken()
                {
                    Id = newTokenId,
                    User = dbUser
                });

                await _userTokenRepository.Remove(userToken);

                return new ReauthenticateResponse(bearerToken, refreshToken);
            }
            catch (TokenGenerationException e)
            {
                throw new HttpInternalServerErrorException(e.Message);
            }
        }

        public async Task<WhoAmIResponse> WhoAmIAsync(User user)
        {
            return await Task.Run(() => new WhoAmIResponse(user));
        }
        
        public async Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordRequest request)
        {
            if (request == null)
            {
                throw new HttpBadRequestException("Request is null");
            }

            if (string.IsNullOrEmpty(request.EmailAddress))
            {
                throw new HttpBadRequestException("Email Address not supplied");
            }

            if (!Validations.IsValidEmailAddress(request.EmailAddress))
            {
                throw new HttpBadRequestException("Email Address isn't valid");
            }

            var dbUser = await _userRepository.GetByEmailAddress(request.EmailAddress);
            if (dbUser == null)
            {
                return new ForgotPasswordResponse(true);
            }

            var dbUserPrompt = new DbUserPrompt
            {
                Type = DbUserPromptTypeEnum.PasswordReset,
                User = dbUser,
                Status = DbUserPromptStatusEnum.Pending
            };
            
            await _userPromptRepository.Add(dbUserPrompt);
            
            _emailService.SendForgottenPasswordEmail(dbUser.EmailAddress, dbUser.Name, dbUserPrompt.Id);

            return new ForgotPasswordResponse(true);
        }

        public async Task<ResetPasswordResponse> ResetPasswordAsync(ResetPasswordRequest request)
        {
            if (request == null)
            {
                throw new HttpBadRequestException("Request is null");
            }

            var newPassword = request.NewPassword;
            var resetId = request.UserPromptId;

            if (string.IsNullOrEmpty(newPassword) || resetId == Guid.Empty)
            {
                throw new HttpBadRequestException("Reset Id or password not supplied");
            }

            var userPrompt = await _userPromptRepository.GetValidPasswordResetPrompt(resetId);
            if (userPrompt == null)
            {
                throw new HttpBadRequestException("Invalid Reset Request");
            }

            newPassword = Cryptography.HashString(newPassword, out var salt);

            userPrompt.User.Password = newPassword;
            userPrompt.User.PasswordSalt = salt;
            userPrompt.User.PasswordAttempts = 0;
            userPrompt.User.Status = DbUserStatusTypeEnum.Active;
            userPrompt.User.UserTokens.Clear();
            userPrompt.Status = DbUserPromptStatusEnum.Used;

            await _userPromptRepository.Update(userPrompt);

            return new ResetPasswordResponse(true);
        }

        public async Task<CheckPasswordResetResponse> CheckPasswordResetAsync(CheckPasswordResetRequest request)
        {
            if (request == null)
            {
                throw new HttpBadRequestException("Request is null");
            }

            var resetId = request.UserPromptId;
            if (resetId == Guid.Empty)
            {
                throw new HttpBadRequestException("Reset Id not supplied");
            }

            var passwordReset =
                await _userPromptRepository.GetValidPasswordResetPrompt(resetId);
            return new CheckPasswordResetResponse(passwordReset != null);
        }

        public async Task<RegisterResponse> RegisterAsync(RegisterRequest request)
        {
            if (request == null)
            {
                throw new HttpBadRequestException("Request is null");
            }

            if (string.IsNullOrEmpty(request.EmailAddress))
            {
                throw new HttpBadRequestException("Email Address not supplied");
            }

            if (!Validations.IsValidEmailAddress(request.EmailAddress))
            {
                throw new HttpBadRequestException("Email Address isn't valid");
            }

            if (string.IsNullOrEmpty(request.Password))
            {
                throw new HttpBadRequestException("Password not supplied");
            }

            var existingUser = await _userRepository.GetByEmailAddress(request.EmailAddress);
            if (existingUser != null)
            {
                throw new HttpBadRequestException("User already exists in the system");
            }

            DbUserPrompt dbUserPrompt = new()
            {
                Type = DbUserPromptTypeEnum.EmailVerification
            };

            var password = Cryptography.HashString(request.Password, out var salt);

            var dbUser = new DbUser
            {
                EmailAddress = request.EmailAddress,
                Password = password,
                PasswordSalt = salt,
                Name = request.Name ?? "",
                PasswordAttempts = 0,
                Status = DbUserStatusTypeEnum.RequiresEmailVerification,
                UserPrompts = new List<DbUserPrompt>
                {
                    dbUserPrompt
                },
            };

            await _userRepository.Add(dbUser);

            _emailService.SendRegistrationEmail(dbUser.EmailAddress, dbUser.Name, dbUserPrompt.Id);

            return new RegisterResponse(true);
        }

        public async Task<ConfirmEmailAddressResponse> ConfirmEmailAddressAsync(ConfirmEmailAddressRequest request)
        {
            if (request == null)
            {
                throw new HttpBadRequestException("Request is null");
            }

            var userPromptId = request.UserPromptId;

            if (userPromptId == Guid.Empty)
            {
                throw new HttpBadRequestException("user Prompt Id not supplied");
            }

            var userPrompt = await _userPromptRepository.GetValidEmailVerficationPrompt(userPromptId);
            if (userPrompt == null)
            {
                throw new HttpBadRequestException("Invalid Confirm Email Address Request");
            }

            if (userPrompt.User.Status != DbUserStatusTypeEnum.RequiresEmailVerification)
            {
                throw new HttpBadRequestException("User doesn't require email verification");
            }

            userPrompt.User.Status = DbUserStatusTypeEnum.Active;
            userPrompt.Status = DbUserPromptStatusEnum.Used;

            await _userPromptRepository.Update(userPrompt);

            return new ConfirmEmailAddressResponse(true);
        }

        public async Task<RequestEmailAddressConfirmationResponse> RequestEmailAddressConfirmationAsync(RequestEmailAddressConfirmationRequest request)
        {
            if (request == null)
            {
                throw new HttpBadRequestException("Request is null");
            }

            if (string.IsNullOrEmpty(request.EmailAddress))
            {
                throw new HttpBadRequestException("Email Address not supplied");
            }

            if (!Validations.IsValidEmailAddress(request.EmailAddress))
            {
                throw new HttpBadRequestException("Email Address isn't valid");
            }
            
            var existingUser = await _userRepository.GetByEmailAddress(request.EmailAddress);
            switch (existingUser)
            {
                case null:
                {
                    // Cant find user.
                    return new RequestEmailAddressConfirmationResponse(true);
                }
                case {Status: DbUserStatusTypeEnum.Disabled} or { Status: DbUserStatusTypeEnum.Locked }:
                {
                    // Cant, user disabled or locked.
                    return new RequestEmailAddressConfirmationResponse(true);
                }
                case {Status: DbUserStatusTypeEnum.Active}:
                {
                    // User has already verified email.
                    _emailService.SendEmailAddressAlreadyConfirmation(existingUser.EmailAddress, existingUser.Name);
                    return new RequestEmailAddressConfirmationResponse(true);
                }
            }

            DbUserPrompt dbUserPrompt = new()
            {
                Type = DbUserPromptTypeEnum.EmailVerification,
                Status = DbUserPromptStatusEnum.Pending,
            };

            existingUser.UserPrompts.Add(dbUserPrompt);
            
            await _userRepository.Update(existingUser);

            _emailService.SendEmailAddressConfirmation(existingUser.EmailAddress, existingUser.Name, dbUserPrompt.Id);

            return new RequestEmailAddressConfirmationResponse(true);
        }

        public async Task<LogoutResponse> LogoutAsync(User user)
        {
            if (user == null)
            {
                throw new HttpBadRequestException("Unable to sign you out");
            }

            var tokenId = user.GetTokenId();
            if (tokenId == null)
            {
                throw new HttpBadRequestException("Unable to sign you out");
            }

            var token = await _userTokenRepository.GetById(tokenId.Value);
            if (token == null)
            {
                return new LogoutResponse(true);
            }

            await _userTokenRepository.Remove(token);
            return new LogoutResponse(true);
        }

        public async Task<ForceLogoutResponse> ForceLogoutAsync(User user)
        {
            if (user == null)
            {
                throw new HttpBadRequestException("Unable to sign you out");
            }

            if (user.Id == null)
            {
                throw new HttpBadRequestException("Unable to sign you out");
            }

            var dbUser = await _userRepository.GetById(user.Id.Value);
            if (dbUser == null)
            {
                return new ForceLogoutResponse(true);
            }

            dbUser.UserTokens.Clear();
            await _userRepository.Update(dbUser);
            
            return new ForceLogoutResponse(true);
        }
    }
}
