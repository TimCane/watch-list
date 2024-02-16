using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WatchList.API.Middleware;
using WatchList.Core.Models;

namespace WatchList.API.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public bool AdminOnly { get; }

        public AuthorizeAttribute(bool adminOnly)
        {
            AdminOnly = adminOnly;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            if (context.HttpContext.Items[JwtMiddleware.ContextKey] is not User user)
            {   // not logged in
                context.Result = new JsonResult(new { message = "Unauthorized" })
                    { StatusCode = StatusCodes.Status401Unauthorized };
                return;
            }

            if (AdminOnly && !user.IsAdmin)
            {
                // not admin
                context.Result = new JsonResult(new { message = "Unauthorized" })
                    { StatusCode = StatusCodes.Status401Unauthorized };
                return;
            }
        }
    }
}
