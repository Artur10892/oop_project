using System;
using System.Collections.Generic;

namespace EntityFrameworkDAL.Entities
{
    public class Customer
    {
        public Customer()
        {
            ShipInfos = new HashSet<ShipInfo>();
        }

        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<ShipInfo> ShipInfos { get; set; }
    }
}
