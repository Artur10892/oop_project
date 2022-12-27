namespace AdoDapperBLL.DTO.Requests
{
    public class WarehouseProductRequest
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public int ProductId { get; set; }
        
        public int Quantity { get; set; }
    }
}
