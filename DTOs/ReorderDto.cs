// ReorderRule DTO
public class ReorderRuleDto : BaseDto
{
    public Guid ItemId { get; set; } = default!;
    public int ReorderLevel { get; set; }
    public int ReorderQty { get; set; }
    public int LeadTimeDays { get; set; }
}

// DTO for creating
public class ReorderRuleCreateDto
{
    public Guid ItemId { get; set; } = default!;
    public int ReorderLevel { get; set; }
    public int ReorderQty { get; set; }
    public int LeadTimeDays { get; set; }
}

public class ReorderAlertDto
    {
        public Guid ItemId { get; set; } = default!;
        public string Message { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
    }