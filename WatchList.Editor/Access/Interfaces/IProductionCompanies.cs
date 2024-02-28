using WatchList.Core.Models;
using WatchList.Editor.Models.Requests;
using WatchList.Editor.Models.Responses;

namespace WatchList.Editor.Access.Interfaces
{
    public interface IProductionCompanies
    {
        Task<ProductionCompaniesResponse> Get(User user, PagedRequest request);

        Task<ProductionCompanyResponse> Get(User user, Guid id);

        Task<CreateProductionCompanyResponse> Create(User user, CreateProductionCompanyRequest request);

        Task<UpdateProductionCompanyResponse> Update(User user, Guid id, UpdateProductionCompanyRequest request);

        Task<DeleteProductionCompanyResponse> Delete(User user, Guid id);
    }
}
