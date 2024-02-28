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
    public class ProductionCompanies : IProductionCompanies
    {
        private readonly IMapper _mapper;
        private readonly IProductionCompanyRepository _productionCompanyRepository;

        public ProductionCompanies(IMapper mapper, IProductionCompanyRepository productionCompanyRepository)
        {
            _mapper = mapper;
            _productionCompanyRepository = productionCompanyRepository;
        }

        private static readonly Dictionary<string, IOrderBy> OrderFunctions =
            new(StringComparer.OrdinalIgnoreCase)
            {
                { "Id", new OrderBy<DbProductionCompany,Guid>(x => x.Id) },
                { "Name", new OrderBy<DbProductionCompany,string>(x => x.Name) },
                { "CreatedOn", new OrderBy<DbProductionCompany,DateTime>(x => x.CreatedOn) },
                { "ModifiedOn", new OrderBy<DbProductionCompany,DateTime>(x => x.ModifiedOn) },
                { "CreatedBy", new OrderBy<DbProductionCompany,Guid>(x => x.CreatedBy) },
                { "ModifiedBy", new OrderBy<DbProductionCompany,Guid>(x => x.ModifiedBy) },
            };

        public async Task<ProductionCompaniesResponse> Get(User user, PagedRequest request)
        {
            Expression<Func<DbProductionCompany, bool>>? expr = null;
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

            var (productionCompanies, total) = await _productionCompanyRepository.GetAll(expr, request.Skip, request.Take, sort, (int)request.SortOrder);

            return new ProductionCompaniesResponse()
            {
                Total = total,
                Search = request.Search,
                Skip = request.Skip,
                SortField = request.SortField,
                SortOrder = request.SortOrder,
                Take = request.Take,
                ProductionCompanies = _mapper.Map<List<ProductionCompany>>(productionCompanies)
            };
        }

        public async Task<ProductionCompanyResponse> Get(User user, Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new HttpBadRequestException($"{nameof(id)} is null");
            }

            var productionCompany = await _productionCompanyRepository.GetById(id);

            return new ProductionCompanyResponse(_mapper.Map<ProductionCompany>(productionCompany));
        }

        public async Task<CreateProductionCompanyResponse> Create(User user, CreateProductionCompanyRequest request)
        {
            if (request == null)
            {
                throw new HttpBadRequestException($"{nameof(request)} is null");
            }

            var productionCompany = _mapper.Map<DbProductionCompany>(request);

            await _productionCompanyRepository.Add(productionCompany);

            return new CreateProductionCompanyResponse(_mapper.Map<ProductionCompany>(productionCompany));
        }

        public async Task<UpdateProductionCompanyResponse> Update(User user, Guid id, UpdateProductionCompanyRequest request)
        {
            if (id == Guid.Empty)
            {
                throw new HttpBadRequestException($"{nameof(id)} is null");
            }

            if (request == null)
            {
                throw new HttpBadRequestException($"{nameof(request)} is null");
            }

            var existingProductionCompany = await _productionCompanyRepository.GetById(id);
            if (existingProductionCompany == null)
            {
                throw new HttpBadRequestException($"ProductionCompany with Id: '{id}' doesn't exist");
            }

            existingProductionCompany.Name = !string.IsNullOrWhiteSpace(request.Name) ? request.Name : existingProductionCompany.Name;

            await _productionCompanyRepository.Update(existingProductionCompany);

            return new UpdateProductionCompanyResponse(_mapper.Map<ProductionCompany>(existingProductionCompany));
        }

        public async Task<DeleteProductionCompanyResponse> Delete(User user, Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new HttpBadRequestException($"{nameof(id)} is null");
            }

            var existingProductionCompany = await _productionCompanyRepository.GetById(id);
            if (existingProductionCompany == null)
            {
                return new DeleteProductionCompanyResponse(false);
            }

            await _productionCompanyRepository.Remove(existingProductionCompany);

            return new DeleteProductionCompanyResponse(true);
        }
    }
}
