namespace CatalogOnline_API.Repositories;

using CatalogOnline_API.Interfaces.Repositories;
using CatalogOnline_API.Models;
using MongoDB.Driver;

public class GradeRepository : IGradeRepository
{
    private readonly IMongoCollection<Grade> _grades;

    public GradeRepository(IMongoDatabase database)
    {
        _grades = database.GetCollection<Grade>("Grades");
    }

    public async Task<List<Grade>> GetGradesByStudentAndScienceIdAsync(string studentId, string scienceId)
    {
        return await _grades.Find(g => g.StudentId == studentId && g.ScienceId == scienceId).ToListAsync();
    }

}
