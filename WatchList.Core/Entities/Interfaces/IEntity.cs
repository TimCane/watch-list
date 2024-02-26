namespace WatchList.Core.Entities.Interfaces
{
    public interface IEntity
    {
        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
