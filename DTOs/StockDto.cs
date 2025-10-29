public class StockDto
{
    public int StockId { get; set; }
    public int ItemId { get; set; }
    public int WarehouseId { get; set; }
    public int QuantityOnHand { get; set; }
    public int QuantityReserved { get; set; }
    public int QuantityAvailable { get; set; }
    public string? SerialNo { get; set; }
    public string? BatchNo { get; set; }
    public DateTime LastUpdated { get; set; }
}
