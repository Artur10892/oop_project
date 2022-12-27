using Dapper.Contrib.Extensions;

namespace AdoDapperDAL.Entities
{
    [Table("Locations")]
    public class Location
    {
        public int Id { get; set; }
        public int RegionId { get; set; }
        public string City { get; set; } = null!;
        public string LocalAddress { get; set; } = null!;
    }
}
