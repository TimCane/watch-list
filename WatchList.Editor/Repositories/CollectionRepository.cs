using WatchList.Core.Repositories;
using WatchList.Editor.Data;
using WatchList.Editor.Entities;
using WatchList.Editor.Repositories.Interfaces;

namespace WatchList.Editor.Repositories
{
    public class CollectionRepository : EfRepository<DbCollection, EditorContext>, ICollectionRepository
    {
        public CollectionRepository(EditorContext context) : base(context)
        {
        }
    }
}
