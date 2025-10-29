public class ReorderAlertDto
{
    public int ReorderId { get; set; }
    public int ItemId { get; set; }
    public int WarehouseId { get; set; }
    public int CurrentStock { get; set; }
    public int ReorderLevel { get; set; }
    public int SuggestedQuantity { get; set; }
    public DateTime AlertDate { get; set; }
    public string Status { get; set; } = "Pending";
}
