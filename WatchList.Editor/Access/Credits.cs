using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WatchList.Core.Exceptions;
using WatchList.Core.Interfaces;
using WatchList.Core.Models;
using WatchList.Editor.Access.Interfaces;
using WatchList.Editor.Entities;
using WatchList.Editor.Models;
using WatchList.Editor.Models.Requests;
using WatchList.Editor.Models.Responses;
using WatchList.Editor.Repositories.Interfaces;

namespace WatchList.Editor.Access
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

        private static readonly Dictionary<string, IOrderBy> OrderFunctions =
            new(StringComparer.OrdinalIgnoreCase)
            {
                { "Id", new OrderBy<DbCredit,Guid>(x => x.Id) },
            };

        public async Task<CreditsResponse> Get(User user, PagedRequest request)
        {
            Expression<Func<DbCredit, bool>>? expr = null;
            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                expr = x =>
                    EF.Functions.Like(x.Name, $"%{request.Search}%");
            }

            IOrderBy? sort = null;
            if (!string.IsNullOrWhiteSpace(request.SortField) && OrderFunctions.ContainsKey(request.SortField))
            {
                sort = OrderFunctions[request.SortField];
            }

            var (credits, total) = await _creditRepository.GetAll(expr, request.Skip, request.Take, sort, (int)request.SortOrder);

            return new CreditsResponse()
            {
                Total = total,
                Search = request.Search,
                Skip = request.Skip,
                SortField = request.SortField,
                SortOrder = request.SortOrder,
                Take = request.Take,
                Credits = _mapper.Map<List<Credit>>(credits)
            };
        }

        public async Task<CreditResponse> Get(User user, Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new HttpBadRequestException($"{nameof(id)} is null");
            }

            var credit = await _creditRepository.GetById(id);

            return new CreditResponse(_mapper.Map<Credit>(credit));
        }

        public async Task<CreateCreditResponse> Create(User user, CreateCreditRequest request)
        {
            if (request == null)
            {
                throw new HttpBadRequestException($"{nameof(request)} is null");
            }

            var credit = _mapper.Map<DbCredit>(request);

            await _creditRepository.Add(credit);

            return new CreateCreditResponse(_mapper.Map<Credit>(credit));
        }

        public async Task<UpdateCreditResponse> Update(User user, Guid id, UpdateCreditRequest request)
        {
            if (id == Guid.Empty)
            {
                throw new HttpBadRequestException($"{nameof(id)} is null");
            }

            if (request == null)
            {
                throw new HttpBadRequestException($"{nameof(request)} is null");
            }

            var existingCredit = await _creditRepository.GetById(id);
            if (existingCredit == null)
            {
                throw new HttpBadRequestException($"Credit with Id: '{id}' doesn't exist");
            }

            existingCredit.Name = !string.IsNullOrWhiteSpace(request.Name) ? request.Name : existingCredit.Name;

            await _creditRepository.Update(existingCredit);

            return new UpdateCreditResponse(_mapper.Map<Credit>(existingCredit));
        }

        public async Task<DeleteCreditResponse> Delete(User user, Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new HttpBadRequestException($"{nameof(id)} is null");
            }

            var existingCredit = await _creditRepository.GetById(id);
            if (existingCredit == null)
            {
                return new DeleteCreditResponse(false);
            }

            await _creditRepository.Remove(existingCredit);

            return new DeleteCreditResponse(true);
        }
    }
}
