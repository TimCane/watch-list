using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchList.Core.Models;
using WatchList.Core.Models.Requests;
using WatchList.Core.Models.Responses;
using WatchList.Core.Models.Responses.Interfaces;

namespace WatchList.Core.Access.Interfaces
{
    public interface IProductionCountries
    {
        Task<ProductionCountriesResponse> Get(User user);

        Task<ProductionCountryResponse> Get(User user, Guid id);

        Task<CreateProductionCountryResponse> Create(User user, CreateProductionCountryRequest request);

        Task<UpdateProductionCountryResponse> Update(User user, Guid id, UpdateProductionCountryRequest request);

        Task<DeleteProductionCountryResponse> Delete(User user, Guid id);
    }
}
