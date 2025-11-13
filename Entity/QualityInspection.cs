public class QualityInspection : Base
{
    public Guid ItemId { get; set; } = default!; // FK
    public Guid? BatchId { get; set; } // optional
    public string Result { get; set; } = default!; // Pass/Fail
    public string Remarks { get; set; } = default!;
    public string InspectedBy { get; set; } = default!;
    public DateTime Date { get; set; } = DateTime.UtcNow;

    // Navigation
    public Item? Item { get; set; }
    public Batch? Batch { get; set; }
}
