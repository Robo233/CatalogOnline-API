using CatalogOnline_API.Models;

namespace CatalogOnline_API.Interfaces.Repositories;

public interface IUserRepository
{

    Task AddUserAsync(User user);

}