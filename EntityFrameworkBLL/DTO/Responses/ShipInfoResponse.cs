using System;

namespace EntityFrameworkBLL.DTO.Responses
{
    public class ShipInfoResponse
    {
        public int Id { get; set; }
        public int CustomerUserId { get; set; }
        public string CustomerFullName { get; set; } = null!;
        public int LocationId { get; set; }
        public string FullLocation { get; set; } = null!;
        public int ShipmentTypeCode { get; set; }
    }
}
