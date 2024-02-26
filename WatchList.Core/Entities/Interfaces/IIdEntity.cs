namespace WatchList.Core.Entities.Interfaces
{
    public interface IIdEntity : IEntity
    {
        public Guid Id { get; set; }
    }
}
