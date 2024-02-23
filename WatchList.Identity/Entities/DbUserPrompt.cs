
using System.ComponentModel.DataAnnotations.Schema;
using WatchList.Core.Entities.Interfaces;
using WatchList.Identity.Enums;

namespace WatchList.Identity.Entities
{
    [Table("UserPrompt")]
    public class DbUserPrompt : IEntity
    {
        public virtual DbUser User { get; set; }

        public DbUserPromptTypeEnum Type { get; set; }

        public DbUserPromptStatusEnum Status { get; set; }

        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
