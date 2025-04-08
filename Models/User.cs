/// <summary>
/// Represents a user in the CatalogOnline system.
/// </summary>
namespace CatalogOnline_API.Models;

public class User
{
    /// <summary>
    /// Gets or sets the unique identifier for the user.
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// Gets or sets the hashed password for the user.
    /// </summary>
    public string? PasswordHash { get; set; }

    /// <summary>
    /// Gets or sets the user's first name.
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    /// Gets or sets the user's last name.
    /// </summary>
    public string? LastName { get; set; }
}
