namespace CleanArch_Application.DTO.Requests
{
    public class SupplierPostRequest
    {
        public string CompanyName { get; set; } = null!;
        public int? LocationId { get; set; }
        public string PhoneNum { get; set; } = null!;
    }
}