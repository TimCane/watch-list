using WatchList.Core.Data;
using WatchList.Core.Entities.Editor;
using WatchList.Core.Repositories;
using WatchList.Editor.Repositories.Interfaces;

namespace WatchList.Editor.Repositories
{
    public class CreditRepository : EfRepository<DbCredit, DatabaseContext>, ICreditRepository
    {
        public CreditRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
