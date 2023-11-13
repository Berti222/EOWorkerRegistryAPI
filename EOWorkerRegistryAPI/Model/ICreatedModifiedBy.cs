namespace EOWorkerRegistryAPI.Model
{
    public interface ICreatedModifiedBy
    {
        long? ModifiedBy { get; set; }
        long? CreatedBy { get; set; }
    }
}
