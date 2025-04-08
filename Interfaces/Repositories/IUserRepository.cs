/// <summary>
/// Interface for the user repository that defines methods for user data operations.
/// </summary>
using CatalogOnline_API.Models;

namespace CatalogOnline_API.Interfaces.Repositories;

public interface IUserRepository
{
    /// <summary>
    /// Retrieves a user by their first and last name asynchronously.
    /// </summary>
    /// <param name="firstName">The first name of the user.</param>
    /// <param name="lastName">The last name of the user.</param>
    /// <returns>A task that returns the matching User or null if not found.</returns>
    Task<User?> GetByNameAsync(string firstName, string lastName);

    /// <summary>
    /// Adds a new user to the repository asynchronously.
    /// </summary>
    /// <param name="user">The user to add.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task AddUserAsync(User user);
}
