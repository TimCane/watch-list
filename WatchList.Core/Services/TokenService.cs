using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WatchList.Core.Helpers;
using WatchList.Core.Models;
using WatchList.Core.Services.Interfaces;

namespace WatchList.Core.Services
{
    public class TokenService : ITokenService
    {
        private const double ExpiryDurationMinutes = 30;
        private readonly AppSettings _appSettings;

        public TokenService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
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
            return true;
        }

        public string BuildToken(User user)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, $"{user.Name}"),
            new Claim(ClaimTypes.Email, $"{user.EmailAddress}"),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString() ?? string.Empty),
            new Claim("iat", DateTimeOffset.Now.ToUnixTimeSeconds().ToString(),ClaimValueTypes.Integer )
        };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JwtSecret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(_appSettings.JwtIssuer, _appSettings.JwtIssuer, claims,
                expires: DateTime.Now.AddMinutes(ExpiryDurationMinutes), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

        public string BuildRefreshToken(User user)
        {
            return Cryptography.SimpleEncryptWithPassword($"{user.Id}", _appSettings.JwtSecret);
        }

        public Guid DecryptRefreshToken(string encryptedRefreshToken)
        {
            var payload = Cryptography.SimpleDecryptWithPassword(encryptedRefreshToken, _appSettings.JwtSecret);

            if (!Guid.TryParse(payload, out var id))
            {
                throw new Exception("CANT USE TOKEN");
            }

            return id;
        }
    }
}
