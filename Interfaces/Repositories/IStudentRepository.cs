/// <summary>
/// Interface for the student repository that defines methods for student data operations.
/// </summary>
using CatalogOnline_API.Models;

namespace CatalogOnline_API.Interfaces.Repositories;

public interface IStudentRepository
{
    /// <summary>
    /// Retrieves a list of students by school class ID asynchronously.
    /// </summary>
    /// <param name="classId">The school class ID.</param>
    /// <returns>A task that returns a list of Student objects.</returns>
    Task<List<Student>> GetStudentsByClassIdAsync(string classId);

    /// <summary>
    /// Retrieves a student by their unique ID asynchronously.
    /// </summary>
    /// <param name="id">The student's unique ID.</param>
    /// <returns>A task that returns the matching Student or null if not found.</returns>
    Task<Student?> GetStudentByIdAsync(string id);
}
