namespace CleanArch_Domain.Entities
{
    public class WarehouseProduct
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public int ProductId { get; set; }
        
        public int Quantity { get; set; }

        public virtual Product? Product { get; set; }
    }
}
