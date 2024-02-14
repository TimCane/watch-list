using AutoMapper;
using WatchList.Core.Access.Interfaces;
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

namespace WatchList.Core.Access
{
    public class Users : IUsers
    {
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IEmailService _emailService;
        private readonly IUserPromptRepository _userPromptRepository;
        private readonly IUserRepository _userRepository;

        public Users(ITokenService tokenService, IEmailService emailService, IUserRepository userRepository,
            IUserPromptRepository userPromptRepository, IMapper mapper)
        {
            _tokenService = tokenService;
            _emailService = emailService;
            _userRepository = userRepository;
            _userPromptRepository = userPromptRepository;
            _mapper = mapper;
        }

        public async Task<AuthenticateResponse> AuthenticateAsync(AuthenticateRequest? request)
        {
            if (request == null)
            {
                throw new HttpBadRequestException("Request is null");
            }

            var emailAddress = request.EmailAddress;
            var password = request.Password;

            if (string.IsNullOrEmpty(emailAddress) || string.IsNullOrEmpty(password))
            {
                throw new HttpBadRequestException("Email Address or password not supplied");
            }

            if (!Validations.IsValidEmailAddress(emailAddress))
            {
                throw new HttpBadRequestException("Email Address isn't valid");
            }

            var dbUser = await _userRepository.GetByEmailAddress(emailAddress);
            if (dbUser == null)
            {
                throw new HttpUnauthorizedException("Invalid Email Address / Password");
            }

            if (!dbUser.CanSignIn())
            {
                throw new HttpUnauthorizedException($"Account is '{dbUser.Status}'.");
            }

            if (!Cryptography.VerifyHash(password, dbUser.Password, dbUser.PasswordSalt))
            {
                throw new HttpUnauthorizedException("Invalid Email Address / Password");
            }

            var user = _mapper.Map<User>(dbUser);

            var bearerToken = _tokenService.BuildToken(user);
            var refreshToken = _tokenService.BuildRefreshToken(user);

            return new AuthenticateResponse(bearerToken, refreshToken);
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

            var userId = _tokenService.DecryptRefreshToken(request.RefreshToken);

            var dbUser = await _userRepository.GetById(userId);
            if (dbUser == null)
            {
                throw new HttpUnauthorizedException("Invalid User");
            }

            var user = _mapper.Map<User>(dbUser);

            var bearerToken = _tokenService.BuildToken(user);
            var refreshToken = _tokenService.BuildRefreshToken(user);
            return new ReauthenticateResponse(bearerToken, refreshToken);
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

            var emailAddress = request.EmailAddress;
            if (string.IsNullOrEmpty(emailAddress))
            {
                throw new HttpBadRequestException("Email Address not supplied");
            }

            if (!Validations.IsValidEmailAddress(emailAddress))
            {
                throw new HttpBadRequestException("Email Address isn't valid");
            }

            var dbUser = await _userRepository.GetByEmailAddress(emailAddress);
            if (dbUser == null)
            {
                return new ForgotPasswordResponse(true);
            }

            var dbUserPrompt = new DbUserPrompt
            {
                Type = DbUserPromptTypeEnum.PasswordReset,
                User = dbUser
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
            userPrompt.Used = true;

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
                throw new HttpBadRequestException("User doesnt require email verification");
            }

            userPrompt.User.Status = DbUserStatusTypeEnum.Active;
            userPrompt.Used = true;

            await _userPromptRepository.Update(userPrompt);

            return new ConfirmEmailAddressResponse(true);
        }

        public async Task<RequestEmailAddressConfirmationResponse> RequestEmailAddressConfirmationAsync(RequestEmailAddressConfirmationRequest request)
        {
            if (request == null)
            {
                throw new HttpBadRequestException("Request is null");
            }

            if (!Validations.IsValidEmailAddress(request.EmailAddress))
            {
                throw new HttpBadRequestException("Email Address isn't valid");
            }
            
            var existingUser = await _userRepository.GetByEmailAddress(request.EmailAddress);
            if (existingUser == null)
            {
                return new RequestEmailAddressConfirmationResponse(true);
            }

            DbUserPrompt dbUserPrompt = new()
            {
                Type = DbUserPromptTypeEnum.EmailVerification
            };
            

            existingUser.UserPrompts.Add(dbUserPrompt);


            await _userRepository.Update(existingUser);

            _emailService.SendEmailAddressConfirmation(existingUser.EmailAddress, existingUser.Name, dbUserPrompt.Id);

            return new RequestEmailAddressConfirmationResponse(true);
        }
    }
}
