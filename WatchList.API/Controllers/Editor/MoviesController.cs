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
    public class MoviesController : BaseController
    {
        private readonly IMovies _movies;

        public MoviesController(IMovies movies, ILogger<MoviesController> logger) : base(logger)
        {
            _movies = movies;
        }

        [HttpGet]
        [Authorize(adminOnly: true)]
        [Produces("application/json")]
        [SwaggerOperation(OperationId = nameof(GetAll))]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(MoviesResponse), contentTypes: "application/json")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(string),
            description: "The server was unable to process the request", contentTypes: "text/plain")]
        public async Task<IActionResult> GetAll([FromQuery][Required] PagedRequest request)
        {
            return await DoRequest(request, _movies.Get);
        }

        [HttpGet("{id:guid}")]
        [Authorize(adminOnly: true)]
        [Produces("application/json")]
        [SwaggerOperation(OperationId = nameof(Get))]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(MovieResponse), contentTypes: "application/json")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(string),
            description: "The server was unable to process the request", contentTypes: "text/plain")]
        public async Task<IActionResult> Get(Guid id)
        {
            return await DoRequest(id, _movies.Get);
        }

        [HttpPost]
        [Authorize(adminOnly: true)]
        [Produces("application/json")]
        [SwaggerOperation(OperationId = nameof(Create))]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(CreateMovieResponse), contentTypes: "application/json")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(string),
            description: "The server was unable to process the request", contentTypes: "text/plain")]
        public async Task<IActionResult> Create(CreateMovieRequest request)
        {
            return await DoRequest(request, _movies.Create);
        }

        [HttpPut("{id:guid}")]
        [Authorize(adminOnly: true)]
        [Produces("application/json")]
        [SwaggerOperation(OperationId = nameof(Update))]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(UpdateMovieResponse), contentTypes: "application/json")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(string),
            description: "The server was unable to process the request", contentTypes: "text/plain")]
        public async Task<IActionResult> Update(Guid id, UpdateMovieRequest request)
        {
            return await DoRequest(id, request, _movies.Update);
        }

        [HttpDelete("{id:guid}")]
        [Authorize(adminOnly: true)]
        [Produces("application/json")]
        [SwaggerOperation(OperationId = nameof(Delete))]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(DeleteMovieResponse), contentTypes: "application/json")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(string),
            description: "The server was unable to process the request", contentTypes: "text/plain")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return await DoRequest(id, _movies.Delete);
        }
    }
}
