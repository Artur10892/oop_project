namespace AdoDapperBLL.DTO.Responses
{
    public class SupplierResponse
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } = null!;
        public int LocationId { get; set; }
        public string PhoneNum { get; set; } = null!;
    }
}
