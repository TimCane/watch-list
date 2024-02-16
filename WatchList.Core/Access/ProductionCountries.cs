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
    public class ProductionCountries : IProductionCountries
    {
        private readonly IMapper _mapper;
        private readonly IProductionCountryRepository _productioncountryRepository;

        public ProductionCountries(IMapper mapper, IProductionCountryRepository productioncountryRepository)
        {
            _mapper = mapper;
            _productioncountryRepository = productioncountryRepository;
        }

        public async Task<ProductionCountriesResponse> Get(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductionCountryResponse> Get(User user, Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<CreateProductionCountryResponse> Create(User user, CreateProductionCountryRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<UpdateProductionCountryResponse> Update(User user, Guid id, UpdateProductionCountryRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<DeleteProductionCountryResponse> Delete(User user, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
