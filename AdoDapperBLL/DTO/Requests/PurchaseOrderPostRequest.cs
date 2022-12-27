using System;
using System.Collections.Generic;

namespace AdoDapperBLL.DTO.Requests
{
    public class PurchaseOrderPostRequest
    {
        public int WarehouseId { get; set; }
        public DateTime Date { get; set; }
        
        public IEnumerable<ProductSubRequest> products { get; set; }
    }
}
