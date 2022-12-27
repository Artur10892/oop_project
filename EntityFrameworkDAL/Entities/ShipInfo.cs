using System;
using System.Collections.Generic;

namespace EntityFrameworkDAL.Entities
{
    public class ShipInfo
    {
        public ShipInfo()
        {
            SalesOrders = new HashSet<SalesOrder>();
        }

        public int Id { get; set; }
        public int CustomerUserId { get; set; }
        public int LocationId { get; set; }
        public int ShipmentTypeCode { get; set; }

        public virtual Customer CustomerUser { get; set; }
        public virtual ICollection<SalesOrder> SalesOrders { get; set; }
    }
}
