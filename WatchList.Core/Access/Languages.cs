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
    public class Languages : ILanguages
    {
        private readonly IMapper _mapper;
        private readonly ILanguageRepository _languageRepository;

        public Languages(IMapper mapper, ILanguageRepository languageRepository)
        {
            _mapper = mapper;
            _languageRepository = languageRepository;
        }

        public async Task<LanguagesResponse> Get(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<LanguageResponse> Get(User user, Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<CreateLanguageResponse> Create(User user, CreateLanguageRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<UpdateLanguageResponse> Update(User user, Guid id, UpdateLanguageRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<DeleteLanguageResponse> Delete(User user, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
