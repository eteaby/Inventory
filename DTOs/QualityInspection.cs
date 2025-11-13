// 12. QualityInspection DTO
public class QualityInspectionDto : BaseDto
{
    public Guid ItemId { get; set; } = default!;
    public Guid BatchId { get; set; } = default!;
    public string Result { get; set; } = default!;
    public string Remarks { get; set; } = default!;
    public string InspectedBy { get; set; } = default!;
    public DateTime Date { get; set; }
}
