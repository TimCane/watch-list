using WatchList.Core.Repositories;
using WatchList.Editor.Data;
using WatchList.Editor.Entities;
using WatchList.Editor.Repositories.Interfaces;

namespace WatchList.Editor.Repositories
{
    public class CreditRepository : EfRepository<DbCredit, EditorContext>, ICreditRepository
    {
        public CreditRepository(EditorContext context) : base(context)
        {
        }
    }
}
