public class Batch : Base
{
    public Guid ItemId { get; set; } = default!; // FK
    public string BatchNumber { get; set; } = default!;
    public DateTime ManufactureDate { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public int Quantity { get; set; } = 0;

    // Navigation
    public Item? Item { get; set; }
    public List<SerialNumber> SerialNumbers { get; set; } = new List<SerialNumber>();
    public List<QualityInspection> QualityInspections { get; set; } = new List<QualityInspection>();
    public List<BarcodeTag> BarcodeTags { get; set; } = new List<BarcodeTag>();
}
