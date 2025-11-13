public class Container : Base
{
    public string ContainerCode { get; set; } = default!;
    public Guid ItemId { get; set; } = default!; // FK
    public int Quantity { get; set; } = default!;
    public double Weight { get; set; } = default!;
    public string Dimensions { get; set; } = default!;
    public string LabelUrl { get; set; } = default!;

    // Navigation
    public Item? Item { get; set; }
}
