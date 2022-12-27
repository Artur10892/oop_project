namespace CleanArch_Application.DTO.Requests
{
    public class LocationPostRequest
    {
        public int? RegionId { get; set; }
        public string City { get; set; } = null!;
        public string LocalAddress { get; set; } = null!;
    }
}