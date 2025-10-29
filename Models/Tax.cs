public class Tax
{
    public int TaxId { get; set; }
    public string TaxName { get; set; } = string.Empty;  // e.g., VAT, Service Tax
    public decimal Rate { get; set; }                    // e.g., 15%
    public bool IsIncludedInPrice { get; set; }         // true = included in item price

    // Navigation
    public ICollection<PurchaseOrderItemTax>? PurchaseOrderItemTaxes { get; set; }
}
