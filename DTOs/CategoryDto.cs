
public class CategoryDto : BaseDto  //DELETE,UPDATE,GETALL AND GET BY ID
{
    public string CategoryName { get; set; } = default!;
    public string Description { get; set; } = default!;
}
public class CategoryCreateDto
{
    public string CategoryName { get; set; } = null!;
    public string Description { get; set; } = default!;
}
