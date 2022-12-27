namespace CleanArch_Application.DTO.Responses
{
    public class SupplierResponse
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } = null!;
        public int LocationId { get; set; }
        public string PhoneNum { get; set; } = null!;
        
        public string RegionName { get; set; } = null!;
        public string City { get; set; } = null!;
        public string LocalAddress { get; set; } = null!;
    }
}