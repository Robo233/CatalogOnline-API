/// <summary>
/// Repository for accessing and manipulating User data in MongoDB.
/// </summary>
using CatalogOnline_API.Interfaces.Repositories;
using CatalogOnline_API.Models;
using MongoDB.Driver;

public class UserRepository : IUserRepository
{
    /// <summary>
    /// MongoDB collection for User entities.
    /// </summary>
    private readonly IMongoCollection<User> _users;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserRepository"/> class with the specified MongoDB database.
    /// </summary>
    /// <param name="database">The MongoDB database instance.</param>
    public UserRepository(IMongoDatabase database)
    {
        _users = database.GetCollection<User>("Users");
    }

    /// <summary>
    /// Adds a new user to the MongoDB collection asynchronously.
    /// </summary>
    /// <param name="user">The user to add.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task AddUserAsync(User user)
    {
        await _users.InsertOneAsync(user);
    }

    /// <summary>
    /// Retrieves a user by first and last name asynchronously.
    /// </summary>
    /// <param name="firstName">The first name of the user.</param>
    /// <param name="lastName">The last name of the user.</param>
    /// <returns>A task that returns the matching user or null if not found.</returns>
    public async Task<User?> GetByNameAsync(string firstName, string lastName)
    {
        return await _users
            .Find(u => u.FirstName == firstName && u.LastName == lastName)
            .FirstOrDefaultAsync();
    }
}
