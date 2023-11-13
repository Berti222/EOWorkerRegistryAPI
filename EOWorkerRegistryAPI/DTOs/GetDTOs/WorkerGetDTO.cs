namespace EOWorkerRegistryAPI.DTOs.GetDTOs
{
    public class WorkerGetDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Rank { get; set; }
        public string PhoneNumber { get; set; }
        public OrganizationalUnitGetDTO OrganizationalUnit { get; set; }
        public WorkerGetDTO Superior { get; set; }
    }
}
