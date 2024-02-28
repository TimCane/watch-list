using WatchList.Core.Data;
using WatchList.Core.Entities.Editor;
using WatchList.Core.Repositories;
using WatchList.Editor.Repositories.Interfaces;

namespace WatchList.Editor.Repositories
{
    public class ProductionCompanyRepository : EfRepository<DbProductionCompany, DatabaseContext>, IProductionCompanyRepository
    {
        public ProductionCompanyRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
