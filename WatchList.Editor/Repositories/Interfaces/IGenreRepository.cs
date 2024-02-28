using WatchList.Core.Entities.Editor;
using WatchList.Core.Repositories;

namespace WatchList.Editor.Repositories.Interfaces
{
    public interface IGenreRepository : IAsyncRepository<DbGenre>
    {
    }
}
