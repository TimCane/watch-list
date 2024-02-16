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
    public class Credits : ICredits
    {
        private readonly IMapper _mapper;
        private readonly ICreditRepository _creditRepository;

        public Credits(IMapper mapper, ICreditRepository creditRepository)
        {
            _mapper = mapper;
            _creditRepository = creditRepository;
        }

        public async Task<CreditsResponse> Get(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<CreditResponse> Get(User user, Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<CreateCreditResponse> Create(User user, CreateCreditRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<UpdateCreditResponse> Update(User user, Guid id, UpdateCreditRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<DeleteCreditResponse> Delete(User user, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
