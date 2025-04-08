namespace CatalogOnline_API.Interfaces.Repositories;

using CatalogOnline_API.Models;
using System.Threading.Tasks;

public interface IGradeRepository
{
    Task<List<Grade>> GetGradesByStudentAndScienceIdAsync(string studentId, string scienceId);
    Task<Grade> GetGradeByIdAsync(string id);
    Task UpsertGradeAsync(Grade grade);
    Task<bool> DeleteGradeAsync(string id);
}
