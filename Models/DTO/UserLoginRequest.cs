/// <summary>
/// Represents the data required for a user login request.
/// </summary>
namespace CatalogOnline_API.Models.DTO;

public class UserLoginRequest
{
    /// <summary>
    /// Gets or sets the first name of the user attempting to login.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name of the user attempting to login.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets the password of the user attempting to login.
    /// </summary>
    public string Password { get; set; }
}
