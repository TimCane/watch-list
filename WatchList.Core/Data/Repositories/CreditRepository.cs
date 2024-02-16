using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchList.Core.Data.Entities;
using WatchList.Core.Data.Repositories.Interfaces;

namespace WatchList.Core.Data.Repositories
{
    public class CreditRepository : EfRepository<DbCredit>, ICreditRepository
    {
        public CreditRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
