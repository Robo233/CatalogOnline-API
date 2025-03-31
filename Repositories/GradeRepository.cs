namespace CatalogOnline_API.Repositories;

using CatalogOnline_API.Interfaces.Repositories;
using CatalogOnline_API.Models;
using MongoDB.Driver;
using System.Threading.Tasks;

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

    public async Task<Grade> GetGradeByIdAsync(string id)
    {
        return await _grades.Find(g => g.Id == id).FirstOrDefaultAsync();
    }

    public async Task UpsertGradeAsync(Grade grade)
    {
        if (string.IsNullOrEmpty(grade.Id))
        {
            grade.Id = Guid.NewGuid().ToString();
            await _grades.InsertOneAsync(grade);
        }
        else
        {
            var filter = Builders<Grade>.Filter.Eq(g => g.Id, grade.Id);
            await _grades.ReplaceOneAsync(filter, grade, new ReplaceOptions { IsUpsert = true });
        }
    }

    public async Task<bool> DeleteGradeAsync(string id)
    {
        var result = await _grades.DeleteOneAsync(g => g.Id == id);
        return result.DeletedCount > 0;
    }
}
