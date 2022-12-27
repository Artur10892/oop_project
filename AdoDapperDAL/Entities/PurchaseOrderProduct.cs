

using Dapper.Contrib.Extensions;

namespace AdoDapperDAL.Entities
{
    [Table("PurchaseOrderProducts")]
    public class PurchaseOrderProduct
    {
        public int Id { get; set; }
        public int PurchaseOrderId { get; set; }
        public int ProductId { get; set; }
        public int OrderedQuantity { get; set; }
    }
}
