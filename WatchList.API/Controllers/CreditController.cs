
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WatchList.API.Attributes;
using WatchList.Core.Access.Interfaces;
using WatchList.Core.Models.Requests;
using WatchList.Core.Models.Responses;

namespace WatchList.API.Controllers
{
    public class CreditsController : BaseController
    {
        private readonly ICredits _credits;

        public CreditsController(ICredits credits, ILogger<CreditsController> logger) : base(logger)
        {
            _credits = credits;
        }

        [HttpGet]
        [Authorize(adminOnly: true)]
        [Produces("application/json")]
        [SwaggerOperation(OperationId = nameof(GetAll))]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(CreditsResponse), contentTypes: "application/json")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(string),
            description: "The server was unable to process the request", contentTypes: "text/plain")]
        public async Task<IActionResult> GetAll()
        {
            return await DoRequest(_credits.Get);
        }

        [HttpGet("{id:guid}")]
        [Authorize(adminOnly: true)]
        [Produces("application/json")]
        [SwaggerOperation(OperationId = nameof(Get))]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(CreditResponse), contentTypes: "application/json")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(string),
            description: "The server was unable to process the request", contentTypes: "text/plain")]
        public async Task<IActionResult> Get(Guid id)
        {
            return await DoRequest(id, _credits.Get);
        }

        [HttpPost]
        [Authorize(adminOnly: true)]
        [Produces("application/json")]
        [SwaggerOperation(OperationId = nameof(Create))]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(CreateCreditResponse), contentTypes: "application/json")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(string),
            description: "The server was unable to process the request", contentTypes: "text/plain")]
        public async Task<IActionResult> Create(CreateCreditRequest request)
        {
            return await DoRequest(request, _credits.Create);
        }

        [HttpPut("{id:guid}")]
        [Authorize(adminOnly: true)]
        [Produces("application/json")]
        [SwaggerOperation(OperationId = nameof(Update))]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(UpdateCreditResponse), contentTypes: "application/json")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(string),
            description: "The server was unable to process the request", contentTypes: "text/plain")]
        public async Task<IActionResult> Update(Guid id, UpdateCreditRequest request)
        {
            return await DoRequest(id, request, _credits.Update);
        }

        [HttpDelete("{id:guid}")]
        [Authorize(adminOnly: true)]
        [Produces("application/json")]
        [SwaggerOperation(OperationId = nameof(Delete))]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(DeleteCreditResponse), contentTypes: "application/json")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(string),
            description: "The server was unable to process the request", contentTypes: "text/plain")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return await DoRequest(id, _credits.Delete);
        }
    }
}
