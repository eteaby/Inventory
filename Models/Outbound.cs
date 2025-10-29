public class Outbound
{
    public int OutboundId { get; set; }
    public int ItemId { get; set; }
    public int WarehouseId { get; set; }
    public int QuantityIssued { get; set; }
    public DateTime DateIssued { get; set; }
    public int IssuedBy { get; set; }
    public string? BatchNo { get; set; }
    public string? SerialNo { get; set; }

    // Navigation
    public Item? Item { get; set; }
    public Warehouse? Warehouse { get; set; }
    public User? Issuer { get; set; }
}
