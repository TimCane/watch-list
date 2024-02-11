using Microsoft.AspNetCore.Mvc;
using WatchList.API.Middleware;
using WatchList.Core.Exceptions;
using WatchList.Core.Models;
using WatchList.Core.Models.Responses.Interfaces;

namespace WatchList.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        private readonly ILogger<BaseController> _logger;

        public BaseController(ILogger<BaseController> logger)
        {
            _logger = logger;
        }

        internal async Task<IActionResult> DoUnauthorisedRequest<TResponse, TRequest>(TRequest request,
            Func<TRequest, Task<TResponse>> func)
            where TResponse : IResponse
        {
            return await ActionResult(async () =>
            {
                CheckRequest(request);
                return await func(request);
            });
        }

        internal async Task<IActionResult> DoRequest<TResponse>(Func<User, Task<TResponse>> func)
            where TResponse : IResponse
        {
            return await ActionResult(async () =>
            {
                var user = GetUser();
                return await func(user);
            });
        }

        internal async Task<IActionResult> DoRequest<TResponse, TRequest>(TRequest request,
            Func<User, TRequest, Task<TResponse>> func)
            where TResponse : IResponse
        {
            return await ActionResult(async () =>
            {
                var user = GetUser();
                CheckRequest(request);

                return await func(user, request);
            });
        }

        internal async Task<IActionResult> DoRequest<TResponse, TRequest, TId>(TId id, TRequest request,
            Func<User, TId, TRequest, Task<TResponse>> func) where TResponse : IResponse
        {
            return await ActionResult(async () =>
            {
                var user = GetUser();
                CheckRequest(request);

                return await func(user, id, request);
            });
        }

        private static void CheckRequest<TRequest>(TRequest request)
        {
            if (request == null) throw new HttpBadRequestException("missing request object");
        }

        internal User GetUser()
        {
            return HttpContext.Items[JwtMiddleware.ContextKey] as User ?? throw new HttpUnauthorizedException();
        }

        private async Task<IActionResult> ActionResult<TResponse>(Func<Task<TResponse>> func) where TResponse : IResponse
        {
            try
            {
                return Ok(await func());
            }
            catch (HttpBadRequestException e)
            {
                _logger.LogInformation("BadRequest: {e.Message}", e.Message);
                return BadRequest(e.Message);
            }
            catch (HttpUnauthorizedException e)
            {
                _logger.LogInformation("Unauthorized: {e.Message}", e.Message);
                return Unauthorized(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError("Problem: {e.Message}", e.Message);
                return Problem(e.Message);
            }
        }
    }
}
