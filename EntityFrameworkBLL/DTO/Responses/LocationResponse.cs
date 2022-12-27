namespace EntityFrameworkBLL.DTO.Responses
{
    public class LocationResponse
    {
        public int Id { get; set; }
        public int RegionId { get; set; }
        public string RegionName { get; set; } = null!;
        public string City { get; set; } = null!;
        public string LocalAddress { get; set; } = null!;
    }
}