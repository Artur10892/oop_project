using System.Collections.Generic;

namespace CleanArch_Domain.Entities
{
    public class Location
    {
        public Location()
        {
            Suppliers = new HashSet<Supplier>();
        }

        public int Id { get; set; }
        public int RegionId { get; set; }
        public string City { get; set; } = null!;
        public string LocalAddress { get; set; } = null!;

        public virtual Region RegionNavigation { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
