namespace CatalogOnline_API.Repositories;

using CatalogOnline_API.Interfaces.Repositories;
using CatalogOnline_API.Models;
using MongoDB.Driver;

public class ScienceRepository : IScienceRepository
{
    private readonly IMongoCollection<Science> _sciences;

    public ScienceRepository(IMongoDatabase database)
    {
        _sciences = database.GetCollection<Science>("Sciences");
    }

    public async Task<List<Science>> GetSciencesByIdsAsync(List<string> scienceIds)
    {
        return await _sciences.Find(s => scienceIds.Contains(s.Id)).ToListAsync();
    }

}