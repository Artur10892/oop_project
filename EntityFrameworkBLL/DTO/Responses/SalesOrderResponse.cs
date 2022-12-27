using System;

namespace EntityFrameworkBLL.DTO.Responses
{
    public class SalesOrderResponse
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; } = null!;
        public int ShipInfoId { get; set; }
        public string CustomerFullName { get; set; } = null!;
        public DateTime Date { get; set; }
        public int OrderStatusCode { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
