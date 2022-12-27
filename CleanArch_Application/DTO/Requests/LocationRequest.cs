namespace CleanArch_Application.DTO.Requests
{
    public class LocationRequest
    {
        public int Id { get; set; }
        public int? RegionId { get; set; }
        public string City { get; set; } = null!;
        public string LocalAddress { get; set; } = null!;
    }
}