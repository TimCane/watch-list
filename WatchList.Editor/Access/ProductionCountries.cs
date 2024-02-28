using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WatchList.Core.Entities.Editor;
using WatchList.Core.Exceptions;
using WatchList.Core.Interfaces;
using WatchList.Core.Models;
using WatchList.Editor.Access.Interfaces;
using WatchList.Editor.Models;
using WatchList.Editor.Models.Requests;
using WatchList.Editor.Models.Responses;
using WatchList.Editor.Repositories.Interfaces;

namespace WatchList.Editor.Access
{
    public class ProductionCountries : IProductionCountries
    {
        private readonly IMapper _mapper;
        private readonly IProductionCountryRepository _productionCountryRepository;

        public ProductionCountries(IMapper mapper, IProductionCountryRepository productionCountryRepository)
        {
            _mapper = mapper;
            _productionCountryRepository = productionCountryRepository;
        }

        private static readonly Dictionary<string, IOrderBy> OrderFunctions =
            new(StringComparer.OrdinalIgnoreCase)
            {
                { "Id", new OrderBy<DbProductionCountry,Guid>(x => x.Id) },
                { "Iso", new OrderBy<DbProductionCountry,string>(x => x.Iso) },
                { "Name", new OrderBy<DbProductionCountry,string>(x => x.Name) },
                { "CreatedOn", new OrderBy<DbProductionCountry,DateTime>(x => x.CreatedOn) },
                { "ModifiedOn", new OrderBy<DbProductionCountry,DateTime>(x => x.ModifiedOn) },
                { "CreatedBy", new OrderBy<DbProductionCountry,Guid>(x => x.CreatedBy) },
                { "ModifiedBy", new OrderBy<DbProductionCountry,Guid>(x => x.ModifiedBy) },
            };

        public async Task<ProductionCountriesResponse> Get(User user, PagedRequest request)
        {
            Expression<Func<DbProductionCountry, bool>>? expr = null;
            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                expr = x =>
                    EF.Functions.Like(x.Name, $"%{request.Search}%");
            }

            IOrderBy? sort = null;
            if (!string.IsNullOrWhiteSpace(request.SortField) && OrderFunctions.ContainsKey(request.SortField))
            {
                sort = OrderFunctions[request.SortField];
            }

            var (productionCountries, total) = await _productionCountryRepository.GetAll(expr, request.Skip, request.Take, sort, (int)request.SortOrder);

            return new ProductionCountriesResponse()
            {
                Total = total,
                Search = request.Search,
                Skip = request.Skip,
                SortField = request.SortField,
                SortOrder = request.SortOrder,
                Take = request.Take,
                ProductionCountries = _mapper.Map<List<ProductionCountry>>(productionCountries)
            };
        }

        public async Task<ProductionCountryResponse> Get(User user, Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new HttpBadRequestException($"{nameof(id)} is null");
            }

            var productionCountry = await _productionCountryRepository.GetById(id);

            return new ProductionCountryResponse(_mapper.Map<ProductionCountry>(productionCountry));
        }

        public async Task<CreateProductionCountryResponse> Create(User user, CreateProductionCountryRequest request)
        {
            if (request == null)
            {
                throw new HttpBadRequestException($"{nameof(request)} is null");
            }

            var productionCountry = _mapper.Map<DbProductionCountry>(request);

            await _productionCountryRepository.Add(productionCountry);

            return new CreateProductionCountryResponse(_mapper.Map<ProductionCountry>(productionCountry));
        }

        public async Task<UpdateProductionCountryResponse> Update(User user, Guid id, UpdateProductionCountryRequest request)
        {
            if (id == Guid.Empty)
            {
                throw new HttpBadRequestException($"{nameof(id)} is null");
            }

            if (request == null)
            {
                throw new HttpBadRequestException($"{nameof(request)} is null");
            }

            var existingProductionCountry = await _productionCountryRepository.GetById(id);
            if (existingProductionCountry == null)
            {
                throw new HttpBadRequestException($"ProductionCountry with Id: '{id}' doesn't exist");
            }

            existingProductionCountry.Name = !string.IsNullOrWhiteSpace(request.Name) ? request.Name : existingProductionCountry.Name;

            await _productionCountryRepository.Update(existingProductionCountry);

            return new UpdateProductionCountryResponse(_mapper.Map<ProductionCountry>(existingProductionCountry));
        }

        public async Task<DeleteProductionCountryResponse> Delete(User user, Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new HttpBadRequestException($"{nameof(id)} is null");
            }

            var existingProductionCountry = await _productionCountryRepository.GetById(id);
            if (existingProductionCountry == null)
            {
                return new DeleteProductionCountryResponse(false);
            }

            await _productionCountryRepository.Remove(existingProductionCountry);

            return new DeleteProductionCountryResponse(true);
        }
    }
}
