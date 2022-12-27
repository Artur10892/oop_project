namespace EntityFrameworkBLL.DTO.Requests
{
    public class ShipInfoRequest
    {
        public int Id { get; set; }
        public int CustomerUserId { get; set; }
        public int LocationId { get; set; }
        public int ShipmentTypeCode { get; set; }
    }
}
