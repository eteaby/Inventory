public class OutboundDto
{
    public int OutboundId { get; set; }
    public int ItemId { get; set; }
    public int WarehouseId { get; set; }
    public int QuantityIssued { get; set; }
    public string? BatchNo { get; set; }
    public string? SerialNo { get; set; }
    public DateTime DateIssued { get; set; }
    public int IssuedBy { get; set; }
    public int? IssuerUserId { get; set; }
}
