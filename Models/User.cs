public enum UserRole
{
    Admin,
    Warehouse,
    Procurement,
    Finance
}

public class User
{
    public int UserId { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public UserRole Role { get; set; }
    public int? AssignedWarehouseId { get; set; }

    // Navigation
    public Warehouse? AssignedWarehouse { get; set; }
}
