/// <summary>
/// Repository for accessing and manipulating Student data in MongoDB.
/// </summary>
using CatalogOnline_API.Interfaces.Repositories;
using CatalogOnline_API.Models;
using MongoDB.Driver;

public class StudentRepository : IStudentRepository
{
    /// <summary>
    /// MongoDB collection for Student entities.
    /// </summary>
    private readonly IMongoCollection<Student> _students;

    /// <summary>
    /// Initializes a new instance of the <see cref="StudentRepository"/> class with the specified MongoDB database.
    /// </summary>
    /// <param name="database">The MongoDB database instance.</param>
    public StudentRepository(IMongoDatabase database)
    {
        _students = database.GetCollection<Student>("Students");
    }

    /// <summary>
    /// Retrieves a list of students associated with a given class ID asynchronously.
    /// </summary>
    /// <param name="classId">The ID of the school class.</param>
    /// <returns>A task that returns a list of students in the specified class.</returns>
    public async Task<List<Student>> GetStudentsByClassIdAsync(string classId)
    {
        return await _students.Find(s => s.ClassId == classId).ToListAsync();
    }

    /// <summary>
    /// Retrieves a student by their unique ID asynchronously.
    /// </summary>
    /// <param name="id">The student's unique ID.</param>
    /// <returns>A task that returns the matching student or null if not found.</returns>
    public async Task<Student?> GetStudentByIdAsync(string id)
    {
        return await _students.Find(c => c.Id == id).FirstOrDefaultAsync();
    }
}
