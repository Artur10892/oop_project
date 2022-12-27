namespace EntityFrameworkDAL.Entities
{
    public class WarehouseProduct
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public int ProductId { get; set; }
        
        public int Quantity { get; set; }
    }
}
