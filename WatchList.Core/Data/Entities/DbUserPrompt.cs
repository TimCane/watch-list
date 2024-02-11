using System.ComponentModel.DataAnnotations.Schema;
using WatchList.Core.Data.Entities.Enums;
using WatchList.Core.Data.Entities.Interfaces;

namespace WatchList.Core.Data.Entities
{
    [Table("UserPrompts")]
    public class DbUserPrompt : IEntity
    {
        public virtual DbUser User { get; set; }

        public DbUserPromptTypeEnum Type { get; set; }

        public bool Used { get; set; }

        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
