namespace EntityFrameworkBLL.DTO.Requests
{
    public class ShipInfoPostRequest
    {
        public int CustomerUserId { get; set; }
        public int LocationId { get; set; }
        public int ShipmentTypeCode { get; set; }
    }
}
