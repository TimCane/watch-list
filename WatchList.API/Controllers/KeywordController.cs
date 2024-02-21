
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WatchList.API.Attributes;
using WatchList.Core.Access.Interfaces;
using WatchList.Core.Models.Requests;
using WatchList.Core.Models.Responses;

namespace WatchList.API.Controllers
{
    public class KeywordsController : BaseController
    {
        private readonly IKeywords _keywords;

        public KeywordsController(IKeywords keywords, ILogger<KeywordsController> logger) : base(logger)
        {
            _keywords = keywords;
        }

        [HttpGet]
        [Authorize(adminOnly: true)]
        [Produces("application/json")]
        [SwaggerOperation(OperationId = nameof(GetAll))]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(KeywordsResponse), contentTypes: "application/json")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(string),
            description: "The server was unable to process the request", contentTypes: "text/plain")]
        public async Task<IActionResult> GetAll()
        {
            return await DoRequest(_keywords.Get);
        }

        [HttpGet("{id:guid}")]
        [Authorize(adminOnly: true)]
        [Produces("application/json")]
        [SwaggerOperation(OperationId = nameof(Get))]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(KeywordResponse), contentTypes: "application/json")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(string),
            description: "The server was unable to process the request", contentTypes: "text/plain")]
        public async Task<IActionResult> Get(Guid id)
        {
            return await DoRequest(id, _keywords.Get);
        }

        [HttpPost]
        [Authorize(adminOnly: true)]
        [Produces("application/json")]
        [SwaggerOperation(OperationId = nameof(Create))]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(CreateKeywordResponse), contentTypes: "application/json")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(string),
            description: "The server was unable to process the request", contentTypes: "text/plain")]
        public async Task<IActionResult> Create(CreateKeywordRequest request)
        {
            return await DoRequest(request, _keywords.Create);
        }

        [HttpPut("{id:guid}")]
        [Authorize(adminOnly: true)]
        [Produces("application/json")]
        [SwaggerOperation(OperationId = nameof(Update))]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(UpdateKeywordResponse), contentTypes: "application/json")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(string),
            description: "The server was unable to process the request", contentTypes: "text/plain")]
        public async Task<IActionResult> Update(Guid id, UpdateKeywordRequest request)
        {
            return await DoRequest(id, request, _keywords.Update);
        }

        [HttpDelete("{id:guid}")]
        [Authorize(adminOnly: true)]
        [Produces("application/json")]
        [SwaggerOperation(OperationId = nameof(Delete))]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(DeleteKeywordResponse), contentTypes: "application/json")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(string),
            description: "The server was unable to process the request", contentTypes: "text/plain")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return await DoRequest(id, _keywords.Delete);
        }
    }
}
