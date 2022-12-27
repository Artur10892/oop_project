namespace CleanArch_Application.DTO.Requests
{
    public class SupplierRequest
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } = null!;
        public int? LocationId { get; set; }
        public string PhoneNum { get; set; } = null!;
    }
}