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
    public class ProductionCountriesController : BaseController
    {
        private readonly IProductionCountries _productionCountries;

        public ProductionCountriesController(IProductionCountries productionCountries, ILogger<ProductionCountriesController> logger) : base(logger)
        {
            _productionCountries = productionCountries;
        }

        [HttpGet]
        [Authorize(adminOnly: true)]
        [Produces("application/json")]
        [SwaggerOperation(OperationId = nameof(GetAll))]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(ProductionCountriesResponse), contentTypes: "application/json")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(string),
            description: "The server was unable to process the request", contentTypes: "text/plain")]
        public async Task<IActionResult> GetAll([FromQuery][Required] PagedRequest request)
        {
            return await DoRequest(request, _productionCountries.Get);
        }

        [HttpGet("{id:guid}")]
        [Authorize(adminOnly: true)]
        [Produces("application/json")]
        [SwaggerOperation(OperationId = nameof(Get))]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(ProductionCountryResponse), contentTypes: "application/json")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(string),
            description: "The server was unable to process the request", contentTypes: "text/plain")]
        public async Task<IActionResult> Get(Guid id)
        {
            return await DoRequest(id, _productionCountries.Get);
        }

        [HttpPost]
        [Authorize(adminOnly: true)]
        [Produces("application/json")]
        [SwaggerOperation(OperationId = nameof(Create))]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(CreateProductionCountryResponse), contentTypes: "application/json")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(string),
            description: "The server was unable to process the request", contentTypes: "text/plain")]
        public async Task<IActionResult> Create(CreateProductionCountryRequest request)
        {
            return await DoRequest(request, _productionCountries.Create);
        }

        [HttpPut("{id:guid}")]
        [Authorize(adminOnly: true)]
        [Produces("application/json")]
        [SwaggerOperation(OperationId = nameof(Update))]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(UpdateProductionCountryResponse), contentTypes: "application/json")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(string),
            description: "The server was unable to process the request", contentTypes: "text/plain")]
        public async Task<IActionResult> Update(Guid id, UpdateProductionCountryRequest request)
        {
            return await DoRequest(id, request, _productionCountries.Update);
        }

        [HttpDelete("{id:guid}")]
        [Authorize(adminOnly: true)]
        [Produces("application/json")]
        [SwaggerOperation(OperationId = nameof(Delete))]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(DeleteProductionCountryResponse), contentTypes: "application/json")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, type: typeof(string),
            description: "The server was unable to process the request", contentTypes: "text/plain")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return await DoRequest(id, _productionCountries.Delete);
        }
    }
}
