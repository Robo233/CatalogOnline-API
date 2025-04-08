/// <summary>
/// Interface for the school class repository that defines methods for school class data operations.
/// </summary>
using CatalogOnline_API.Models;

namespace CatalogOnline_API.Interfaces.Repositories;

public interface ISchoolClassRepository
{
    /// <summary>
    /// Retrieves all school classes asynchronously.
    /// </summary>
    /// <returns>A task that returns a list of SchoolClass objects.</returns>
    Task<List<SchoolClass>> GetSchoolClassesAsync();

    /// <summary>
    /// Retrieves a school class by its unique ID asynchronously.
    /// </summary>
    /// <param name="id">The unique ID of the school class.</param>
    /// <returns>A task that returns the matching SchoolClass or null if not found.</returns>
    Task<SchoolClass?> GetSchoolClassByIdAsync(string id);
}
