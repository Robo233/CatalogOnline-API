/// <summary>
/// Represents the data required to register a new user.
/// </summary>
namespace CatalogOnline_API.Models.DTO;

public class UserRegisterRequest
{
    /// <summary>
    /// Gets or sets the first name of the user.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name of the user.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets the password for the user.
    /// </summary>
    public string Password { get; set; }
}
