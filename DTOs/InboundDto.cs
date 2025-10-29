public class InboundDto
{
    public int InboundId { get; set; }
    public int ItemId { get; set; }
    public int WarehouseId { get; set; }
    public int SupplierId { get; set; }
    public int QuantityReceived { get; set; }
    public string GRNNumber { get; set; } = string.Empty;
    public string? BatchNo { get; set; }
    public string? SerialNo { get; set; }
    public DateTime DateReceived { get; set; }
    public int ReceivedBy { get; set; }
    public int? ReceiverUserId { get; set; }
}
