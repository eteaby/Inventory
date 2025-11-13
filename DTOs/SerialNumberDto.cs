public class SerialNumberDto : BaseDto
{
    public Guid ItemId { get; set; } = default!;
    public Guid? BatchId { get; set; }
    public string SerialCode { get; set; } = default!;
    public string Status { get; set; } = default!;
}

public class SerialNumberCreateDto
{
    public string ItemId { get; set; } = default!;
    public Guid? BatchId { get; set; }
    public string SerialCode { get; set; } = default!;
    public string Status { get; set; } = "Available";
}
