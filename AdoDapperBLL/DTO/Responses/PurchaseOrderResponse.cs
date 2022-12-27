using System;

namespace AdoDapperBLL.DTO.Responses
{
    public class PurchaseOrderResponse
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public DateTime Date { get; set; }
        public int OrderStatusCode { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
