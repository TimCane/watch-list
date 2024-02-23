using WatchList.Core.Repositories;
using WatchList.Editor.Data;
using WatchList.Editor.Entities;
using WatchList.Editor.Repositories.Interfaces;

namespace WatchList.Editor.Repositories
{
    public class ProductionCountryRepository : EfRepository<DbProductionCountry, EditorContext>, IProductionCountryRepository
    {
        public ProductionCountryRepository(EditorContext context) : base(context)
        {
        }
    }
}
