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
    public interface ILanguages
    {
        Task<LanguagesResponse> Get(User user);

        Task<LanguageResponse> Get(User user, Guid id);

        Task<CreateLanguageResponse> Create(User user, CreateLanguageRequest request);

        Task<UpdateLanguageResponse> Update(User user, Guid id, UpdateLanguageRequest request);

        Task<DeleteLanguageResponse> Delete(User user, Guid id);
    }
}
