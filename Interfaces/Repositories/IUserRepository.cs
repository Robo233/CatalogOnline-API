using CatalogOnline_API.Models;

namespace CatalogOnline_API.Interfaces.Repositories;

public interface IUserRepository
{
    Task<User?> GetByNameAsync(string firstName, string lastName);
    Task AddUserAsync(User user);

}