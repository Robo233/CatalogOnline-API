/// <summary>
/// Repository for accessing and manipulating Grade data in MongoDB.
/// </summary>
using CatalogOnline_API.Interfaces.Repositories;
using CatalogOnline_API.Models;
using MongoDB.Driver;

public class GradeRepository : IGradeRepository
{
    /// <summary>
    /// MongoDB collection for Grade entities.
    /// </summary>
    private readonly IMongoCollection<Grade> _grades;

    /// <summary>
    /// Initializes a new instance of the <see cref="GradeRepository"/> class with the specified MongoDB database.
    /// </summary>
    /// <param name="database">The MongoDB database instance.</param>
    public GradeRepository(IMongoDatabase database)
    {
        _grades = database.GetCollection<Grade>("Grades");
    }

    /// <summary>
    /// Retrieves a list of grades for a specific student and science ID asynchronously.
    /// </summary>
    /// <param name="studentId">The student's unique ID.</param>
    /// <param name="scienceId">The science subject's unique ID.</param>
    /// <returns>A task that returns a list of Grade objects.</returns>
    public async Task<List<Grade>> GetGradesByStudentAndScienceIdAsync(string studentId, string scienceId)
    {
        return await _grades.Find(g => g.StudentId == studentId && g.ScienceId == scienceId).ToListAsync();
    }
}
