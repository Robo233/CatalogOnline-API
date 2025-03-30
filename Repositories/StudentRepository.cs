namespace CatalogOnline_API.Repositories;

using CatalogOnline_API.Interfaces.Repositories;
using CatalogOnline_API.Models;
using MongoDB.Driver;

public class StudentRepository : IStudentRepository
{
    private readonly IMongoCollection<Student> _students;

    public StudentRepository(IMongoDatabase database)
    {
        _students = database.GetCollection<Student>("Students");
    }

    public async Task<List<Student>> GetStudentsByClassIdAsync(string classId)
    {
        return await _students.Find(s => s.ClassId == classId).ToListAsync();
    }

    public async Task<Student?> GetStudentByIdAsync(string id)
    {
        return await _students.Find(c => c.Id == id).FirstOrDefaultAsync();
    }

}
