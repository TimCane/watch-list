using System.Net;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WatchList.API.Attributes;
using WatchList.Core.Access.Interfaces;
using WatchList.Core.Models.Requests;
using WatchList.Core.Models.Responses;

namespace WatchList.API.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IUsers _users;

        public UsersController(IUsers users, ILogger<UsersController> logger) : base(logger)
        {
            _users = users;
        }

        [HttpPost]
        [Route("authenticate")]
        [Produces("application/json")]
        [SwaggerOperation(OperationId = nameof(Authenticate))]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(AuthenticateResponse), contentTypes: "application/json")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(string),
            description: "The server was unable to process the request", contentTypes: "text/plain")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateRequest request)
        {
            return await DoUnauthorisedRequest(request, _users.AuthenticateAsync);
        }

        [HttpPost]
        [Route("register")]
        [Produces("application/json")]
        [SwaggerOperation(OperationId = nameof(Register))]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(RegisterResponse), contentTypes: "application/json")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(string),
            description: "The server was unable to process the request", contentTypes: "text/plain")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            return await DoUnauthorisedRequest(request, _users.RegisterAsync);
        }

        [HttpPost]
        [Route("reauthenticate")]
        [Produces("application/json")]
        [SwaggerOperation(OperationId = nameof(Reauthenticate))]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(ReauthenticateResponse), contentTypes: "application/json")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(string),
            description: "The server was unable to process the request", contentTypes: "text/plain")]
        public async Task<IActionResult> Reauthenticate([FromBody] ReauthenticateRequest request)
        {
            return await DoUnauthorisedRequest(request, _users.ReauthenticateAsync);
        }

        [HttpPost]
        [Route("check-password-reset")]
        [Produces("application/json")]
        [SwaggerOperation(OperationId = nameof(CheckPasswordReset))]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(CheckPasswordResetResponse),
            contentTypes: "application/json")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(string),
            description: "The server was unable to process the request", contentTypes: "text/plain")]
        public async Task<IActionResult> CheckPasswordReset([FromBody] CheckPasswordResetRequest request)
        {
            return await DoUnauthorisedRequest(request, _users.CheckPasswordResetAsync);
        }

        [HttpPost]
        [Route("forgot-password")]
        [Produces("application/json")]
        [SwaggerOperation(OperationId = nameof(ForgotPassword))]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(ForgotPasswordResponse), contentTypes: "application/json")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(string),
            description: "The server was unable to process the request", contentTypes: "text/plain")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            return await DoUnauthorisedRequest(request, _users.ForgotPasswordAsync);
        }

        [HttpPost]
        [Route("reset-password")]
        [Produces("application/json")]
        [SwaggerOperation(OperationId = nameof(ResetPassword))]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(ResetPasswordResponse), contentTypes: "application/json")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(string),
            description: "The server was unable to process the request", contentTypes: "text/plain")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            return await DoUnauthorisedRequest(request, _users.ResetPasswordAsync);
        }

        [HttpPost]
        [Route("confirm-email-address")]
        [Produces("application/json")]
        [SwaggerOperation(OperationId = nameof(ConfirmEmailAddress))]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(ConfirmEmailAddressResponse),
            contentTypes: "application/json")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(string),
            description: "The server was unable to process the request", contentTypes: "text/plain")]
        public async Task<IActionResult> ConfirmEmailAddress([FromBody] ConfirmEmailAddressRequest request)
        {
            return await DoUnauthorisedRequest(request, _users.ConfirmEmailAddressAsync);
        }

        [HttpPost]
        [Route("request-email-address-confirmation")]
        [Produces("application/json")]
        [SwaggerOperation(OperationId = nameof(RequestEmailAddressConfirmation))]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(RequestEmailAddressConfirmationResponse),
            contentTypes: "application/json")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(string),
            description: "The server was unable to process the request", contentTypes: "text/plain")]
        public async Task<IActionResult> RequestEmailAddressConfirmation([FromBody] RequestEmailAddressConfirmationRequest request)
        {
            return await DoUnauthorisedRequest(request, _users.RequestEmailAddressConfirmationAsync);
        }

        [HttpGet]
        [Authorize]
        [Route("whoami")]
        [Produces("application/json")]
        [SwaggerOperation(OperationId = nameof(WhoAmI))]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(WhoAmIResponse), contentTypes: "application/json")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(string),
            description: "The server was unable to process the request", contentTypes: "text/plain")]
        public async Task<IActionResult> WhoAmI()
        {
            return await DoRequest(_users.WhoAmIAsync);
        }
    }
}
