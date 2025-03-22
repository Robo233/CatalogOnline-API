namespace CatalogOnline_API.Models.DTO;

public class UserLoginRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
}