using WatchList.Core.Repositories;
using WatchList.Editor.Entities;

namespace WatchList.Editor.Repositories.Interfaces
{
    public interface IGenreRepository : IAsyncRepository<DbGenre>
    {
    }
}
