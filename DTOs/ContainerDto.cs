// Container DTO
public class ContainerDto : BaseDto
{
    public string ContainerCode { get; set; } = default!;
    public Guid ItemId { get; set; } = default!;
    public int Quantity { get; set; }
    public double Weight { get; set; }
    public string Dimensions { get; set; } = default!;
    public string LabelUrl { get; set; } = default!;
}

// DTO for creating a Container
public class ContainerCreateDto
{
    public string ContainerCode { get; set; } = default!;
    public string ItemId { get; set; } = default!;
    public int Quantity { get; set; }
    public double Weight { get; set; }
    public string Dimensions { get; set; } = default!;
    public string LabelUrl { get; set; } = default!;
}
