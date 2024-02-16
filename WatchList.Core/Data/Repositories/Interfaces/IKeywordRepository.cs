using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchList.Core.Data.Entities;

namespace WatchList.Core.Data.Repositories.Interfaces
{
    public interface IKeywordRepository : IAsyncRepository<DbKeyword>
    {
    }
}
