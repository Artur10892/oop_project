namespace BlazorApp.Data.Models
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public string SupplierCompanyName { get; set; } = null!;
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? Image { get; set; }
        public string Name { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SellPrice { get; set; }
        public string Description { get; set; } = null!;
    }
}