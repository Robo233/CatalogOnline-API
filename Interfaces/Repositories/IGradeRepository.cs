/// <summary>
/// Interface for the grade repository that defines methods for grade data operations.
/// </summary>
using CatalogOnline_API.Models;

namespace CatalogOnline_API.Interfaces.Repositories;

public interface IGradeRepository
{
    /// <summary>
    /// Retrieves a list of grades for a specific student and science ID asynchronously.
    /// </summary>
    /// <param name="studentId">The student's unique ID.</param>
    /// <param name="scienceId">The science subject's unique ID.</param>
    /// <returns>A task that returns a list of Grade objects.</returns>
    Task<List<Grade>> GetGradesByStudentAndScienceIdAsync(string studentId, string scienceId);
}
