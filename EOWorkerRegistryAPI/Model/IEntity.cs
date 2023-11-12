namespace EOWorkerRegistryAPI.Model
{
    public interface IEntity
    {
        long Id { get; set; }
        string Name { get; set; }
        bool Active { get; set; }
    }
}
