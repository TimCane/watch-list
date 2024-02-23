using WatchList.Core.Repositories;
using WatchList.Editor.Data;
using WatchList.Editor.Entities;
using WatchList.Editor.Repositories.Interfaces;

namespace WatchList.Editor.Repositories
{
    public class GenreRepository : EfRepository<DbGenre, EditorContext>, IGenreRepository
    {
        public GenreRepository(EditorContext context) : base(context)
        {
        }
    }
}
