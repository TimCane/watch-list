using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WatchList.Core.Exceptions;
using WatchList.Core.Helpers;
using WatchList.Core.Models;
using WatchList.Identity.Repositories.Interfaces;
using WatchList.Identity.Services.Interfaces;

namespace WatchList.Identity.Services
{
    public class TokenService : ITokenService
    {
        public const int ExpiryDurationMinutes = 30;
        private readonly AppSettings _appSettings;
        private readonly IUserTokenRepository _userTokenRepository;

        public TokenService(IOptions<AppSettings> appSettings, IUserTokenRepository userTokenRepository)
        {
            _appSettings = appSettings.Value;
            _userTokenRepository = userTokenRepository;
        }

        public bool IsTokenValid(string token, out JwtSecurityToken? validatedToken)
        {
            SecurityToken? securityToken;

            var secretBytes = Encoding.UTF8.GetBytes(_appSettings.JwtSecret);
            var securityKey = new SymmetricSecurityKey(secretBytes);
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token,
                    new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidIssuer = _appSettings.JwtIssuer,
                        ValidAudience = _appSettings.JwtAudience,
                        IssuerSigningKey = securityKey,

                    }, out securityToken);
            }
            catch
            {
                validatedToken = null;
                return false;
            }

            validatedToken = (JwtSecurityToken)securityToken;
            return validatedToken.ValidTo >= DateTime.Now;
        }

        public string BuildToken(User user, Guid tokenId)
        {
            if (!user.Id.HasValue)
            {
                throw new TokenGenerationException("UserId is empty");
            }

            var claims = new[]
            {
                new Claim("sub", $"{user.Id}"),
                new Claim("iat", DateTimeOffset.Now.ToUnixTimeSeconds().ToString(),ClaimValueTypes.Integer ),
                new Claim("id", $"{tokenId}", ClaimValueTypes.String)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JwtSecret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(_appSettings.JwtIssuer, _appSettings.JwtIssuer, claims,
                expires: DateTime.Now.AddMinutes(ExpiryDurationMinutes), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

        public string BuildRefreshToken(User user, Guid tokenId)
        {
            return Cryptography.SimpleEncryptWithPassword($"{user.Id}:{tokenId}", _appSettings.JwtSecret);
        }

        public Guid DecryptRefreshToken(string encryptedRefreshToken, out Guid tokenId)
        {
            var payload = Cryptography.SimpleDecryptWithPassword(encryptedRefreshToken, _appSettings.JwtSecret);

            var split = payload.Split(":");

            if (split.Length != 2)
            {
                throw new Exception("Refresh token in invalid format");
            }

            var strUserId = split[0];
            var strTokenId = split[1];

            if (!Guid.TryParse(strUserId, out var userId))
            {
                throw new Exception("Unable to parse userId to guid");
            }

            if (!Guid.TryParse(strTokenId, out tokenId))
            {
                throw new Exception("Unable to parse tokenId to guid");
            }

            return userId;
        }

        public async Task ClearExpiredTokens(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var tokensToInvalidate = (await _userTokenRepository.GetWhere(token =>
                token.CreatedOn.AddMinutes(ExpiryDurationMinutes) < DateTime.Now)).ToList();

                if (tokensToInvalidate.Any())
                {
                    await _userTokenRepository.RemoveRange(tokensToInvalidate);
                }

                await Task.Delay(ExpiryDurationMinutes * 60000, stoppingToken);
            }
        }
    }
}
