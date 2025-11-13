public class SerialNumber : Base
{
    public Guid ItemId { get; set; } = default!; // FK
    public Guid? BatchId { get; set; } // FK optional
    public string SerialCode { get; set; } = default!;
    public string Status { get; set; } = default!; // Available/Issued/Returned

    // Navigation
    public Item? Item { get; set; }
    public Batch? Batch { get; set; }
    public List<BarcodeTag> BarcodeTags { get; set; } = new List<BarcodeTag>();
}
