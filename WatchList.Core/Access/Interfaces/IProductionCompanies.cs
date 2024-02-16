using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchList.Core.Models;
using WatchList.Core.Models.Requests;
using WatchList.Core.Models.Responses;

namespace WatchList.Core.Access.Interfaces
{
    public interface IProductionCompanies
    {
        Task<ProductionCompaniesResponse> Get(User user);

        Task<ProductionCompanyResponse> Get(User user, Guid id);

        Task<CreateProductionCompanyResponse> Create(User user, CreateProductionCompanyRequest request);

        Task<UpdateProductionCompanyResponse> Update(User user, Guid id, UpdateProductionCompanyRequest request);

        Task<DeleteProductionCompanyResponse> Delete(User user, Guid id);
    }
}
