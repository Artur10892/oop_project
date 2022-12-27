namespace CleanArch_Application.DTO.Requests
{
    public class ProductPostRequest
    {
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        public string? Image { get; set; }
        public string Name { get; set; } = null!;
        public decimal PurchasePrice { get; set; }
        public decimal SellPrice { get; set; }
        public string Description { get; set; } = null!;
    }
}