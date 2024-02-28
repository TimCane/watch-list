using WatchList.Core.Data;
using WatchList.Core.Entities.Editor;
using WatchList.Core.Repositories;

using WatchList.Editor.Repositories.Interfaces;

namespace WatchList.Editor.Repositories
{
    public class KeywordRepository : EfRepository<DbKeyword, DatabaseContext>, IKeywordRepository
    {
        public KeywordRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
