public class Item : Base
{
    public string ItemName { get; set; } = default!;
    public string SKU { get; set; } = default!;
    public Guid CategoryId { get; set; } = default!; // FK
    public string UnitOfMeasure { get; set; } = default!;
    public int ReorderLevel { get; set; } = 0;
    public int SafetyStock { get; set; } = 0;
    public double CostPrice { get; set; } = 0;
    public double SellingPrice { get; set; } = 0;
    public DateTime? ExpiryDate { get; set; }

    // Navigation
    public Category? Category { get; set; }
    public List<Stock> Stocks { get; set; } = new List<Stock>();
    public List<Batch> Batches { get; set; } = new List<Batch>();
    public List<SerialNumber> SerialNumbers { get; set; } = new List<SerialNumber>();
    public List<ReorderRule> ReorderRules { get; set; } = new List<ReorderRule>();
    public List<StockTransaction> StockTransactions { get; set; } = new List<StockTransaction>();
    public List<StockAdjustment> StockAdjustments { get; set; } = new List<StockAdjustment>();
    public List<StockTransfer> StockTransfers { get; set; } = new List<StockTransfer>();
    public List<QualityInspection> QualityInspections { get; set; } = new List<QualityInspection>();
    public List<BarcodeTag> BarcodeTags { get; set; } = new List<BarcodeTag>();
    public List<Container> Containers { get; set; } = new List<Container>();
    public List<InventoryValuation> InventoryValuations { get; set; } = new List<InventoryValuation>();
}
