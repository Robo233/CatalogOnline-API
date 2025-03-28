namespace CatalogOnline_API.Interfaces.Repositories;

using CatalogOnline_API.Models;

public interface IScienceRepository
{
    Task<List<Science>> GetSciencesByIdsAsync(List<string> scienceIds);
}