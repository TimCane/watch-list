﻿using System.IdentityModel.Tokens.Jwt;
using WatchList.Core.Models;

namespace WatchList.Core.Services.Interfaces
{
    public interface ITokenService
    {
        string BuildToken(User user, Guid tokenId);
        bool IsTokenValid(string token, out JwtSecurityToken? validatedToken);

        public Guid DecryptRefreshToken(string encryptedRefreshToken, out Guid tokenId);
        public string BuildRefreshToken(User user, Guid tokenId);

        public Task ClearExpiredTokens(CancellationToken stoppingToken);
    }
}
