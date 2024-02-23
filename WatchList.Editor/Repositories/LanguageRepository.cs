using WatchList.Core.Repositories;
using WatchList.Editor.Data;
using WatchList.Editor.Entities;
using WatchList.Editor.Repositories.Interfaces;

namespace WatchList.Editor.Repositories
{
    public class LanguageRepository : EfRepository<DbLanguage, EditorContext>, ILanguageRepository
    {
        public LanguageRepository(EditorContext context) : base(context)
        {
        }
    }
}
