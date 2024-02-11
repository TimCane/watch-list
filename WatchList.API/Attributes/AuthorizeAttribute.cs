using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WatchList.API.Middleware;

namespace WatchList.API.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            if (context.HttpContext.Items[JwtMiddleware.ContextKey] == null)
                // not logged in
                context.Result = new JsonResult(new { message = "Unauthorized" })
                    { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}
