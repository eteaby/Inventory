public class Warehouse : Base
{
    public string WarehouseName { get; set; } = default!;
    public string Location { get; set; } = default!;
    public string Manager { get; set; } = default!;

    // Navigation
    public List<StorageLocation> StorageLocations { get; set; } = new List<StorageLocation>();
    public List<Stock> Stocks { get; set; } = new List<Stock>();
    public List<StockTransaction> StockTransactions { get; set; } = new List<StockTransaction>();
    public List<StockAdjustment> StockAdjustments { get; set; } = new List<StockAdjustment>();
    public List<StockTransfer> StockTransfersFrom { get; set; } = new List<StockTransfer>();
    public List<StockTransfer> StockTransfersTo { get; set; } = new List<StockTransfer>();
    public List<CycleCount> CycleCounts { get; set; } = new List<CycleCount>();
}
