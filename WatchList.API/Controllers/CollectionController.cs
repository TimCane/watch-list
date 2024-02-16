
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WatchList.API.Attributes;
using WatchList.Core.Access.Interfaces;
using WatchList.Core.Models.Requests;
using WatchList.Core.Models.Responses;

namespace WatchList.API.Controllers
{
    public class CollectionsController : BaseController
    {
        private readonly ICollections _collections;

        public CollectionsController(ICollections collections, ILogger<CollectionsController> logger) : base(logger)
        {
            _collections = collections;
        }

        [HttpGet]
        [Authorize(adminOnly: true)]
        [Produces("application/json")]
        [SwaggerOperation(OperationId = nameof(GetAll))]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(CollectionsResponse), contentTypes: "application/json")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(string),
            description: "The server was unable to process the request", contentTypes: "text/plain")]
        public async Task<IActionResult> GetAll()
        {
            return await DoRequest(_collections.Get);
        }

        [HttpGet("{id:guid}")]
        [Authorize(adminOnly: true)]
        [Produces("application/json")]
        [SwaggerOperation(OperationId = nameof(Get))]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(CollectionResponse), contentTypes: "application/json")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(string),
            description: "The server was unable to process the request", contentTypes: "text/plain")]
        public async Task<IActionResult> Get(Guid id)
        {
            return await DoRequest(_collections.Get);
        }

        [HttpPost]
        [Authorize(adminOnly: true)]
        [Produces("application/json")]
        [SwaggerOperation(OperationId = nameof(Create))]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(CreateCollectionResponse), contentTypes: "application/json")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(string),
            description: "The server was unable to process the request", contentTypes: "text/plain")]
        public async Task<IActionResult> Create(CreateCollectionRequest request)
        {
            return await DoRequest(request, _collections.Create);
        }

        [HttpPut("{id:guid}")]
        [Authorize(adminOnly: true)]
        [Produces("application/json")]
        [SwaggerOperation(OperationId = nameof(Update))]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(UpdateCollectionResponse), contentTypes: "application/json")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(string),
            description: "The server was unable to process the request", contentTypes: "text/plain")]
        public async Task<IActionResult> Update(Guid id, UpdateCollectionRequest request)
        {
            return await DoRequest(id, request, _collections.Update);
        }

        [HttpDelete("{id:guid}")]
        [Authorize(adminOnly: true)]
        [Produces("application/json")]
        [SwaggerOperation(OperationId = nameof(Delete))]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(DeleteCollectionResponse), contentTypes: "application/json")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(string),
            description: "The server was unable to process the request", contentTypes: "text/plain")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return await DoRequest(id, _collections.Delete);
        }
    }
}
