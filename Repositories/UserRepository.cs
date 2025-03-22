namespace CatalogOnline_API.Repositories;

using CatalogOnline_API.Interfaces.Repositories;
using CatalogOnline_API.Models;
using MongoDB.Driver;

public class UserRepository : IUserRepository
{
    private readonly IMongoCollection<User> _users;

    public UserRepository(IMongoDatabase database)
    {
        _users = database.GetCollection<User>("Users");
    }

    public async Task AddUserAsync(User user)
    {
        await _users.InsertOneAsync(user);
    }

    public async Task<User?> GetByNameAsync(string firstName, string lastName)
    {
        return await _users
            .Find(u => u.FirstName == firstName && u.LastName == lastName)
            .FirstOrDefaultAsync();
    }

}