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

        public async Task Invoke(HttpContext context, IUserRepository userRepository, ITokenService tokenService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
            {
                if (tokenService.IsTokenValid(token, out var validatedToken))
                {
                    var strId = validatedToken?.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;

                    if (!string.IsNullOrWhiteSpace(strId) && Guid.TryParse(strId, out var id))
                    {
                        var dbUser = await userRepository.GetById(id);

                        if (dbUser != null && dbUser.CanSignIn())
                        {
                            var user = _mapper.Map<User>(dbUser);
                            context.Items[ContextKey] = user;
                        }
                    }
                }
            }

            await _next(context);
        }
    }
}
