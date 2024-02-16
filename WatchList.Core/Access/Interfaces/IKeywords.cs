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
    public interface IKeywords
    {
        Task<KeywordsResponse> Get(User user);

        Task<KeywordResponse> Get(User user, Guid id);

        Task<CreateKeywordResponse> Create(User user, CreateKeywordRequest request);

        Task<UpdateKeywordResponse> Update(User user, Guid id, UpdateKeywordRequest request);

        Task<DeleteKeywordResponse> Delete(User user, Guid id);
    }
}
