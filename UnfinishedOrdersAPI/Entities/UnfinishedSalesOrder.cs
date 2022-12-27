using Redis.OM.Modeling;

namespace UnfinishedOrdersAPI.Entities;

[Document(StorageType = StorageType.Json, Prefixes = new []{"UnfinishedSalesOrder"})]
public class UnfinishedSalesOrder
{
    [RedisIdField] [Indexed] public Guid Id { get; set; }
    
    [Indexed]
    public int StageIndex { get; set; }

    [Indexed]
    public int? WarehouseId { get; set; }

    [Indexed]
    public int? ShipInfoId { get; set; }
    
    [Indexed] 
    public DateTime? Date { get; set; }

    [Indexed] 
    public int[] ProductIds { get; set; } = Array.Empty<int>();
    
    [Indexed] 
    public int[] ProductQuantities { get; set; } = Array.Empty<int>();
}