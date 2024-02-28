using Microsoft.AspNetCore.Mvc;
using WatchList.API.Middleware;
using WatchList.Core.Exceptions;
using WatchList.Core.Models;
using WatchList.Core.Models.Interfaces;

namespace WatchList.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        public readonly ILogger<BaseController> Logger;

        public BaseController(ILogger<BaseController> logger)
        {
            Logger = logger;
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
                Logger.LogInformation("BadRequest: {e.Message}", e.Message);
                return BadRequest(e.Message);
            }
            catch (HttpUnauthorizedException e)
            {
                Logger.LogInformation("Unauthorized: {e.Message}", e.Message);
                return Unauthorized(e.Message);
            }
            catch (HttpInternalServerErrorException e)
            {
                Logger.LogInformation("Internal Server Error: {e.Message}", e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception e)
            {
                Logger.LogError("Problem: {e.Message}", e.Message);
                return Problem(e.Message);
            }
        }
    }
}
