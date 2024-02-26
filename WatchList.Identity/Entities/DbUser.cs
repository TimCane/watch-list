using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using WatchList.Core.Entities.Interfaces;
using WatchList.Identity.Enums;

namespace WatchList.Identity.Entities
{
    [Table("User")]
    public class DbUser : IIdEntity
    {
        public string EmailAddress { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        public string PasswordSalt { get; set; }

        public int PasswordAttempts { get; set; }

        public DbUserStatusTypeEnum Status { get; set; }

        public virtual ICollection<DbUserPrompt> UserPrompts { get; set; }
        public virtual ICollection<DbUserToken> UserTokens { get; set; }

        public string Name { get; set; }

        public bool IsAdmin { get; set; }

        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        public bool CanSignIn(out string message)
        {
            switch (Status)
            {
                case DbUserStatusTypeEnum.Active:
                    message = string.Empty;
                    return true;
                case DbUserStatusTypeEnum.Disabled:
                    message = "Your account is disabled";
                    return false;
                case DbUserStatusTypeEnum.RequiresEmailVerification:
                    message = "Please verify your email";
                    return false;
                case DbUserStatusTypeEnum.Locked:
                    message = "Invalid Email Address / Password";
                    return false;
                default:
                    message = string.Empty;
                    return false;
            }
        }
    }
}
