namespace WatchList.Core.Entities.Interfaces
{
    public interface IManyToManyEntity
    {
        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
