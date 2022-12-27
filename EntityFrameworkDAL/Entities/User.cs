using System;
using System.Collections.Generic;

namespace EntityFrameworkDAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Avatar { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual Customer Customer { get; set; } = null!;
    }
}
