using System;

namespace EntityFrameworkBLL.DTO.Requests
{
    public class SalesOrderRequest
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public int? ShipInfoId { get; set; }
        public DateTime Date { get; set; }
        public int OrderStatusCode { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
