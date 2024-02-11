using System.IdentityModel.Tokens.Jwt;
using WatchList.Core.Models;

namespace WatchList.Core.Services.Interfaces
{
    public interface ITokenService
    {
        string BuildToken(User user);
        bool IsTokenValid(string token, out JwtSecurityToken? validatedToken);

        public Guid DecryptRefreshToken(string encryptedRefreshToken);
        public string BuildRefreshToken(User user);
    }
}
