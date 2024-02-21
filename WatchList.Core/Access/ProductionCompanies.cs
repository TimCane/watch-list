using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchList.Core.Access.Interfaces;
using WatchList.Core.Data.Repositories.Interfaces;
using WatchList.Core.Models;
using WatchList.Core.Models.Requests;
using WatchList.Core.Models.Responses;

namespace WatchList.Core.Access
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

        public async Task<ProductionCompaniesResponse> Get(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductionCompanyResponse> Get(User user, Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<CreateProductionCompanyResponse> Create(User user, CreateProductionCompanyRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<UpdateProductionCompanyResponse> Update(User user, Guid id, UpdateProductionCompanyRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<DeleteProductionCompanyResponse> Delete(User user, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
