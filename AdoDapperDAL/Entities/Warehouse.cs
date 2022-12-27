using Dapper.Contrib.Extensions;

namespace AdoDapperDAL.Entities
{
    [Table("Warehouses")]
    public class Warehouse
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public string Name { get; set; } = null!;
    }
}
