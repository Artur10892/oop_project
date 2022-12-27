using System;

namespace EntityFrameworkBLL.DTO.Requests
{
    public class UserPostRequest
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Avatar { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
