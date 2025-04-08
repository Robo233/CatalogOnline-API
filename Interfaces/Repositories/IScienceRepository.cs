/// <summary>
/// Interface for the science repository that defines methods for science data operations.
/// </summary>
using CatalogOnline_API.Models;

namespace CatalogOnline_API.Interfaces.Repositories;

public interface IScienceRepository
{
    /// <summary>
    /// Retrieves a list of sciences by a list of science IDs asynchronously.
    /// </summary>
    /// <param name="scienceIds">A list of science IDs.</param>
    /// <returns>A task that returns a list of Science objects.</returns>
    Task<List<Science>> GetSciencesByIdsAsync(List<string> scienceIds);

    /// <summary>
    /// Retrieves a science by its unique ID asynchronously.
    /// </summary>
    /// <param name="scienceId">The unique ID of the science.</param>
    /// <returns>A task that returns the matching Science object.</returns>
    Task<Science> GetScienceByIdAsync(string scienceId);
}
