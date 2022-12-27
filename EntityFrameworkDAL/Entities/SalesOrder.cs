using System;
using System.Collections.Generic;

namespace EntityFrameworkDAL.Entities
{
    public class SalesOrder
    {
        public SalesOrder()
        {
            SalesOrderProducts = new HashSet<SalesOrderProduct>();
        }

        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public int ShipInfoId { get; set; }
        public DateTime Date { get; set; }
        public int OrderStatusCode { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual ShipInfo ShipInfo { get; set; }
        public virtual ICollection<SalesOrderProduct> SalesOrderProducts { get; set; }
    }
}
