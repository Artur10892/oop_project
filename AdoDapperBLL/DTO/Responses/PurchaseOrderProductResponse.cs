namespace AdoDapperBLL.DTO.Responses
{
    public class PurchaseOrderProductResponse
    {
        public int Id { get; set; }
        public int PurchaseOrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int OrderedQuantity { get; set; }
    }
}
