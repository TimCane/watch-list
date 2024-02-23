using WatchList.Core.Repositories;
using WatchList.Editor.Data;
using WatchList.Editor.Entities;
using WatchList.Editor.Repositories.Interfaces;

namespace WatchList.Editor.Repositories
{
    public class KeywordRepository : EfRepository<DbKeyword, EditorContext>, IKeywordRepository
    {
        public KeywordRepository(EditorContext context) : base(context)
        {
        }
    }
}
