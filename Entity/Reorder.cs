public class ReorderRule : Base
{
    public Guid ItemId { get; set; } = default!; // FK
    public int ReorderLevel { get; set; } = 0;
    public int ReorderQty { get; set; } = 0;
    public int LeadTimeDays { get; set; } = 0;

    // Navigation
    public Item? Item { get; set; }
}
