using System.Collections.Generic;

namespace CleanArch_Domain.Entities
{
    public class Supplier
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string CompanyName { get; set; } = null!;
        public int LocationId { get; set; }
        public string PhoneNum { get; set; } = null!;

        public virtual Location Location { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
