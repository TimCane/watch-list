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
    public interface ICredits
    {
        Task<CreditsResponse> Get(User user);

        Task<CreditResponse> Get(User user, Guid id);

        Task<CreateCreditResponse> Create(User user, CreateCreditRequest request);

        Task<UpdateCreditResponse> Update(User user, Guid id, UpdateCreditRequest request);

        Task<DeleteCreditResponse> Delete(User user, Guid id);
    }
}
