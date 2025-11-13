// 13. BarcodeTag DTO
public class BarcodeTagDto : BaseDto
{
    public Guid ItemId { get; set; } = default!;
    public string TagCode { get; set; } = default!;
    public string Type { get; set; } = default!;
    public string AssignedToLocation { get; set; } = default!;
}
