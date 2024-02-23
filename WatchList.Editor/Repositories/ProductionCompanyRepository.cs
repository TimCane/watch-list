using WatchList.Core.Repositories;
using WatchList.Editor.Data;
using WatchList.Editor.Entities;
using WatchList.Editor.Repositories.Interfaces;

namespace WatchList.Editor.Repositories
{
    public class ProductionCompanyRepository : EfRepository<DbProductionCompany, EditorContext>, IProductionCompanyRepository
    {
        public ProductionCompanyRepository(EditorContext context) : base(context)
        {
        }
    }
}
