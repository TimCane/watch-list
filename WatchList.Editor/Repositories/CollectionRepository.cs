using WatchList.Core.Data;
using WatchList.Core.Entities.Editor;
using WatchList.Core.Repositories;
using WatchList.Editor.Repositories.Interfaces;

namespace WatchList.Editor.Repositories
{
    public class CollectionRepository : EfRepository<DbCollection, DatabaseContext>, ICollectionRepository
    {
        public CollectionRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
