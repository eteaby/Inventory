public class TaxDto
{
    public int TaxId { get; set; }
    public string TaxName { get; set; } = string.Empty;
    public decimal Rate { get; set; }
    public bool IsIncludedInPrice { get; set; }
}
