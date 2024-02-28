using System.ComponentModel.DataAnnotations.Schema;
using WatchList.Core.Entities.Identity.Enums;
using WatchList.Core.Entities.Interfaces;
using WatchList.Core.Models;

namespace WatchList.Core.Entities.Identity
{
    [Table("UserPrompt")]
    public class DbUserPrompt : IIdEntity
    {
        public virtual DbUser User { get; set; }

        public DbUserPromptTypeEnum Type { get; set; }

        public DbUserPromptStatusEnum Status { get; set; }

        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        

        public DateTime ModifiedOn { get; set; }
        public Guid ModifiedBy { get; set; }
        
    }
}
