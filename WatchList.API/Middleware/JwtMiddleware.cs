using System.Security.Claims;
using AutoMapper;
using WatchList.Core.Data.Repositories.Interfaces;
using WatchList.Core.Models;
using WatchList.Core.Services.Interfaces;

namespace WatchList.API.Middleware
{
    public class JwtMiddleware
    {
        public const string ContextKey = "User";
        private readonly IMapper _mapper;

        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next, IMapper mapper)
        {
            _next = next;
            _mapper = mapper;
        }

        public async Task Invoke(HttpContext context, IUserRepository userRepository, IUserTokenRepository userTokenRepository, ITokenService tokenService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
            {
                if (tokenService.IsTokenValid(token, out var validatedToken))
                {
                    var strUserId = validatedToken?.Claims.First(x => x.Type == "sub").Value;
                    var strTokenId = validatedToken?.Claims.First(x => x.Type == "id").Value;

                    if (!string.IsNullOrWhiteSpace(strUserId) && Guid.TryParse(strUserId, out var userId) &&
                        !string.IsNullOrWhiteSpace(strTokenId) && Guid.TryParse(strTokenId, out var tokenId))
                    {
                        var dbUser = await userRepository.GetById(userId);
                        var dbUserToken = await userTokenRepository.GetValidUserToken(userId, tokenId);

                        if (dbUserToken != null && dbUser != null && dbUser.CanSignIn(out _))
                        {
                            var user = _mapper.Map<User>(dbUser);
                            user.SetTokenId(tokenId);
                            context.Items[ContextKey] = user;
                        }
                    }
                }
            }

            await _next(context);
        }
    }
}
