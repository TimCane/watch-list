using WatchList.Core.Models;
using WatchList.Editor.Models.Requests;
using WatchList.Editor.Models.Responses;

namespace WatchList.Editor.Access.Interfaces
{
    public interface ICredits
    {
        Task<CreditsResponse> Get(User user, PagedRequest request);

        Task<CreditResponse> Get(User user, Guid id);

        Task<CreateCreditResponse> Create(User user, CreateCreditRequest request);

        Task<UpdateCreditResponse> Update(User user, Guid id, UpdateCreditRequest request);

        Task<DeleteCreditResponse> Delete(User user, Guid id);
    }
}
