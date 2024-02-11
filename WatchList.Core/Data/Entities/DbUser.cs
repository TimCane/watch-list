using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using WatchList.Core.Data.Entities.Enums;
using WatchList.Core.Data.Entities.Interfaces;

namespace WatchList.Core.Data.Entities
{
    [Table("User")]
    public class DbUser : IEntity
    {
        public string EmailAddress { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        public string PasswordSalt { get; set; }

        public DbUserStatusTypeEnum Status { get; set; }

        public virtual ICollection<DbUserPrompt> UserPrompts { get; set; }

        public string Name { get; set; }

        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        public bool CanSignIn()
        {
            return Status == DbUserStatusTypeEnum.Active;
        }
    }
}
