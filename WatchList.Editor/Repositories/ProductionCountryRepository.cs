using WatchList.Core.Data;
using WatchList.Core.Entities.Editor;
using WatchList.Core.Repositories;
using WatchList.Editor.Repositories.Interfaces;

namespace WatchList.Editor.Repositories
{
    public class ProductionCountryRepository : EfRepository<DbProductionCountry, DatabaseContext>, IProductionCountryRepository
    {
        public ProductionCountryRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
