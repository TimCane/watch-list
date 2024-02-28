namespace WatchList.Core.Models
{
    public class User
    {

        public string? EmailAddress { get; set; }
        public Guid? Id { get; set; }

        public string? Name { get; set; }

        public bool IsAdmin { get; set; }

        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }


        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

        private Guid? _tokenId;

        public Guid? GetTokenId()
        {
            return _tokenId;
        }

        public void SetTokenId(Guid tokenId)
        {
            _tokenId = tokenId;
        }
    }
}
