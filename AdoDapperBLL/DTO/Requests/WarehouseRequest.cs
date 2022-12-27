namespace AdoDapperBLL.DTO.Requests
{
    public class WarehouseRequest
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public string Name { get; set; } = null!;
    }
}
