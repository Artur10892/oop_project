using System;
using Dapper.Contrib.Extensions;

namespace AdoDapperDAL.Entities
{
    [Table("PurchaseOrders")]
    public class PurchaseOrder
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public DateTime Date { get; set; }
        public int OrderStatusCode { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
