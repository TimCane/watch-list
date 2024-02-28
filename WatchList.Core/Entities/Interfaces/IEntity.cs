using WatchList.Core.Entities.Identity;
using WatchList.Core.Models;

namespace WatchList.Core.Entities.Interfaces
{
    public interface IEntity
    {
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }

        public DateTime ModifiedOn { get; set; }
        public Guid ModifiedBy { get; set; }
    }
}
