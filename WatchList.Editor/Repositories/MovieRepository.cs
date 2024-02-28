using WatchList.Core.Data;
using WatchList.Core.Entities.Editor;
using WatchList.Core.Repositories;
using WatchList.Editor.Repositories.Interfaces;

namespace WatchList.Editor.Repositories
{
    public class MovieRepository : EfRepository<DbMovie, DatabaseContext>, IMovieRepository
    {
        public MovieRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
