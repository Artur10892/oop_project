using System;
using System.Collections.Generic;

namespace AdoDapperBLL.DTO.Requests
{
    public class PurchaseOrderRequest
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public DateTime Date { get; set; }
        public int OrderStatusCode { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
