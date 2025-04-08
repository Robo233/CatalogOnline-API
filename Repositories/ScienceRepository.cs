/// <summary>
/// Repository for accessing and manipulating Science data in MongoDB.
/// </summary>
using CatalogOnline_API.Interfaces.Repositories;
using CatalogOnline_API.Models;
using MongoDB.Driver;

public class ScienceRepository : IScienceRepository
{
    /// <summary>
    /// MongoDB collection for Science entities.
    /// </summary>
    private readonly IMongoCollection<Science> _sciences;

    /// <summary>
    /// Initializes a new instance of the <see cref="ScienceRepository"/> class with the specified MongoDB database.
    /// </summary>
    /// <param name="database">The MongoDB database instance.</param>
    public ScienceRepository(IMongoDatabase database)
    {
        _sciences = database.GetCollection<Science>("Sciences");
    }

    /// <summary>
    /// Retrieves a list of Science records that match the specified list of science IDs asynchronously.
    /// </summary>
    /// <param name="scienceIds">A list of science IDs to look up.</param>
    /// <returns>A task that returns a list of Science objects.</returns>
    public async Task<List<Science>> GetSciencesByIdsAsync(List<string> scienceIds)
    {
        return await _sciences.Find(s => scienceIds.Contains(s.Id)).ToListAsync();
    }

    /// <summary>
    /// Retrieves a Science record by its unique ID asynchronously.
    /// </summary>
    /// <param name="id">The unique ID of the Science record.</param>
    /// <returns>A task that returns the matching Science object or null if not found.</returns>
    public async Task<Science?> GetScienceByIdAsync(string id)
    {
        return await _sciences.Find(c => c.Id == id).FirstOrDefaultAsync();
    }
}
