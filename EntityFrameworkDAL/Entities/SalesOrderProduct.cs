using System;
using System.Collections.Generic;

namespace EntityFrameworkDAL.Entities
{
    public class SalesOrderProduct
    {
        public int Id { get; set; }
        public int SalesOrderId { get; set; }
        public int ProductId { get; set; }
        public int SoldQuantity { get; set; }

        public virtual SalesOrder SalesOrder { get; set; }
    }
}
