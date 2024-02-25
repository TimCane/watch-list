using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WatchList.API.Attributes;
using WatchList.Core.Models;
using WatchList.Editor.Access.Interfaces;
using WatchList.Editor.Models.Requests;
using WatchList.Editor.Models.Responses;

namespace WatchList.API.Controllers.Editor
{
    public class LanguagesController : BaseController
    {
        private readonly ILanguages _languages;

        public LanguagesController(ILanguages languages, ILogger<LanguagesController> logger) : base(logger)
        {
            _languages = languages;
        }

        [HttpGet]
        [Authorize(adminOnly: true)]
        [Produces("application/json")]
        [SwaggerOperation(OperationId = "languagesAll")]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(LanguagesResponse), contentTypes: "application/json")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(string),
            description: "The server was unable to process the request", contentTypes: "text/plain")]
        public async Task<IActionResult> GetAll([FromQuery][Required] PagedRequest request)
        {
            return await DoRequest(request, _languages.Get);
        }

        [HttpGet("{id:guid}")]
        [Authorize(adminOnly: true)]
        [Produces("application/json")]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(LanguageResponse), contentTypes: "application/json")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(string),
            description: "The server was unable to process the request", contentTypes: "text/plain")]
        public async Task<IActionResult> Get(Guid id)
        {
            return await DoRequest(id, _languages.Get);
        }

        [HttpPost]
        [Authorize(adminOnly: true)]
        [Produces("application/json")]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(CreateLanguageResponse), contentTypes: "application/json")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(string),
            description: "The server was unable to process the request", contentTypes: "text/plain")]
        public async Task<IActionResult> Create(CreateLanguageRequest request)
        {
            return await DoRequest(request, _languages.Create);
        }

        [HttpPut("{id:guid}")]
        [Authorize(adminOnly: true)]
        [Produces("application/json")]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(UpdateLanguageResponse), contentTypes: "application/json")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(string),
            description: "The server was unable to process the request", contentTypes: "text/plain")]
        public async Task<IActionResult> Update(Guid id, UpdateLanguageRequest request)
        {
            return await DoRequest(id, request, _languages.Update);
        }

        [HttpDelete("{id:guid}")]
        [Authorize(adminOnly: true)]
        [Produces("application/json")]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(DeleteLanguageResponse), contentTypes: "application/json")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(string),
            description: "The server was unable to process the request", contentTypes: "text/plain")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return await DoRequest(id, _languages.Delete);
        }
    }
}