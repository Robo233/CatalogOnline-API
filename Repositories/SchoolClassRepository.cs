/// <summary>
/// Repository for accessing and manipulating SchoolClass data in MongoDB.
/// </summary>
using CatalogOnline_API.Interfaces.Repositories;
using CatalogOnline_API.Models;
using MongoDB.Driver;

public class SchoolClassRepository : ISchoolClassRepository
{
    /// <summary>
    /// MongoDB collection for SchoolClass entities.
    /// </summary>
    private readonly IMongoCollection<SchoolClass> _schoolClasses;

    /// <summary>
    /// Initializes a new instance of the <see cref="SchoolClassRepository"/> class with the specified MongoDB database.
    /// </summary>
    /// <param name="database">The MongoDB database instance.</param>
    public SchoolClassRepository(IMongoDatabase database)
    {
        _schoolClasses = database.GetCollection<SchoolClass>("SchoolClasses");
    }

    /// <summary>
    /// Retrieves all school classes asynchronously.
    /// </summary>
    /// <returns>A task that returns a list of all SchoolClass objects.</returns>
    public async Task<List<SchoolClass>> GetSchoolClassesAsync()
    {
        return await _schoolClasses.Find(_ => true).ToListAsync();
    }

    /// <summary>
    /// Retrieves a school class by its unique ID asynchronously.
    /// </summary>
    /// <param name="id">The unique ID of the school class.</param>
    /// <returns>A task that returns the matching SchoolClass object or null if not found.</returns>
    public async Task<SchoolClass?> GetSchoolClassByIdAsync(string id)
    {
        return await _schoolClasses.Find(c => c.Id == id).FirstOrDefaultAsync();
    }
}
