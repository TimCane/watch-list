using WatchList.Core.Repositories;
using WatchList.Editor.Data;
using WatchList.Editor.Entities;
using WatchList.Editor.Repositories.Interfaces;

namespace WatchList.Editor.Repositories
{
    public class MovieRepository : EfRepository<DbMovie, EditorContext>, IMovieRepository
    {
        public MovieRepository(EditorContext context) : base(context)
        {
        }
    }
}
