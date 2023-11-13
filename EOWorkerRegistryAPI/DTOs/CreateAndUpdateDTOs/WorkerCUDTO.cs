namespace EOWorkerRegistryAPI.DTOs.CreateDTOs
{
    public class WorkerCUDTO
    {
        public string Name { get; set; }
        public string Rank { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public long? SuperiorId { get; set; }
        public long? OrganizationalUnitId { get; set; }
    }
}
