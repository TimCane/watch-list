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
    public class GenresController : BaseController
    {
        private readonly IGenres _genres;

        public GenresController(IGenres genres, ILogger<GenresController> logger) : base(logger)
        {
            _genres = genres;
        }

        [HttpGet]
        [Authorize(adminOnly: true)]
        [Produces("application/json")]
        [SwaggerOperation(OperationId = "genresAll")]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(GenresResponse), contentTypes: "application/json")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(string),
            description: "The server was unable to process the request", contentTypes: "text/plain")]
        public async Task<IActionResult> GetAll([FromQuery][Required] PagedRequest request)
        {
            return await DoRequest(request, _genres.Get);
        }

        [HttpGet("{id:guid}")]
        [Authorize(adminOnly: true)]
        [Produces("application/json")]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(GenreResponse), contentTypes: "application/json")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(string),
            description: "The server was unable to process the request", contentTypes: "text/plain")]
        public async Task<IActionResult> Get(Guid id)
        {
            return await DoRequest(id, _genres.Get);
        }

        [HttpPost]
        [Authorize(adminOnly: true)]
        [Produces("application/json")]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(CreateGenreResponse), contentTypes: "application/json")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(string),
            description: "The server was unable to process the request", contentTypes: "text/plain")]
        public async Task<IActionResult> Create(CreateGenreRequest request)
        {
            return await DoRequest(request, _genres.Create);
        }

        [HttpPut("{id:guid}")]
        [Authorize(adminOnly: true)]
        [Produces("application/json")]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(UpdateGenreResponse), contentTypes: "application/json")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(string),
            description: "The server was unable to process the request", contentTypes: "text/plain")]
        public async Task<IActionResult> Update(Guid id, UpdateGenreRequest request)
        {
            return await DoRequest(id, request, _genres.Update);
        }

        [HttpDelete("{id:guid}")]
        [Authorize(adminOnly: true)]
        [Produces("application/json")]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(DeleteGenreResponse), contentTypes: "application/json")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(string),
            description: "The server was unable to process the request", contentTypes: "text/plain")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return await DoRequest(id, _genres.Delete);
        }
    }
}
