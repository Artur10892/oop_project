using System;

namespace EntityFrameworkBLL.DTO.Responses
{
    public class SalesOrderProductResponse
    {
        public int Id { get; set; }
        public int SalesOrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int SoldQuantity { get; set; }
    }
}
