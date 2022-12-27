namespace Common.Events.OrderEvents
{
    public class FinishedSalesOrderEvent : BaseEvent
    {
        public int WarehouseId { get; set; }
        
        public int ShipInfoId { get; set; }
        
        public DateTime Date { get; set; }
        
        public int[] ProductIds { get; set; } = Array.Empty<int>();

        public int[] ProductQuantities { get; set; } = Array.Empty<int>();
    }
}