using CatalogOnline_API.Models;

namespace CatalogOnline_API.Interfaces.Repositories;

public interface ISchoolClassRepository
{
    Task<List<SchoolClass>> GetSchoolClassesAsync();

}