using System.Collections.Generic;

namespace CleanArch_Domain.Entities
{
    public class Region
    {
        public Region()
        {
            Locations = new HashSet<Location>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Location> Locations { get; set; }
    }
}
