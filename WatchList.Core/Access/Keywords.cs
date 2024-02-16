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
    public class Keywords : IKeywords
    {
        private readonly IMapper _mapper;
        private readonly IKeywordRepository _keywordRepository;

        public Keywords(IMapper mapper, IKeywordRepository keywordRepository)
        {
            _mapper = mapper;
            _keywordRepository = keywordRepository;
        }

        public async Task<KeywordsResponse> Get(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<KeywordResponse> Get(User user, Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<CreateKeywordResponse> Create(User user, CreateKeywordRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<UpdateKeywordResponse> Update(User user, Guid id, UpdateKeywordRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<DeleteKeywordResponse> Delete(User user, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
