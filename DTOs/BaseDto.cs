public class BaseDto
{
    public Guid Id { get; set; } = default!; 
    public DateTime? DateCreated { get; set; } = default!;
    public DateTime? DateModified { get; set; } = default!;
}
