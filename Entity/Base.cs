public class Base
{
    public Guid Id { get; set; } = Guid.NewGuid();  

    // Audit fields
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    public DateTime DateModified { get; set; } = DateTime.UtcNow;
}
