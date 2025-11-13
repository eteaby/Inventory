public class Category : Base
{
    public string CategoryName { get; set; } = default!;
    public string Description { get; set; } = default!;

    // Navigation
    public List<Item> Items { get; set; } = new List<Item>();
}
