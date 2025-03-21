namespace CatalogOnline_API.Models;

public class User
{
    public string? Id { get; set; }
    public string? PasswordHash { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}
