using WatchList.Core.Data;
using WatchList.Core.Entities.Editor;
using WatchList.Core.Repositories;
using WatchList.Editor.Repositories.Interfaces;

namespace WatchList.Editor.Repositories
{
    public class LanguageRepository : EfRepository<DbLanguage, DatabaseContext>, ILanguageRepository
    {
        public LanguageRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
