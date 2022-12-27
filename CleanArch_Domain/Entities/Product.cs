namespace CleanArch_Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        public string? Image { get; set; }
        public string Name { get; set; } = null!;
        public decimal PurchasePrice { get; set; }
        public decimal SellPrice { get; set; }
        public string Description { get; set; } = null!;

        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
