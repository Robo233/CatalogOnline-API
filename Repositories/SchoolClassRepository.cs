using CatalogOnline_API.Interfaces.Repositories;
using CatalogOnline_API.Models;
using MongoDB.Driver;

namespace CatalogOnline_API.Repositories;

public class SchoolClassRepository : ISchoolClassRepository
{
    private readonly IMongoCollection<SchoolClass> _schoolClasses;

    public SchoolClassRepository(IMongoDatabase database)
    {
        _schoolClasses = database.GetCollection<SchoolClass>("SchoolClasses");
    }

    public async Task<List<SchoolClass>> GetSchoolClassesAsync()
    {
        return await _schoolClasses.Find(_ => true).ToListAsync();
    }
}
