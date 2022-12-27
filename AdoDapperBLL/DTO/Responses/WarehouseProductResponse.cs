namespace AdoDapperBLL.DTO.Responses
{
    public class WarehouseProductResponse
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; } = null!;
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        
        public int Quantity { get; set; }
    }
}
