using WatchList.Core.Models;
using WatchList.Editor.Models.Requests;
using WatchList.Editor.Models.Responses;

namespace WatchList.Editor.Access.Interfaces
{
    public interface IProductionCountries
    {
        Task<ProductionCountriesResponse> Get(User user, PagedRequest request);

        Task<ProductionCountryResponse> Get(User user, Guid id);

        Task<CreateProductionCountryResponse> Create(User user, CreateProductionCountryRequest request);

        Task<UpdateProductionCountryResponse> Update(User user, Guid id, UpdateProductionCountryRequest request);

        Task<DeleteProductionCountryResponse> Delete(User user, Guid id);
    }
}
