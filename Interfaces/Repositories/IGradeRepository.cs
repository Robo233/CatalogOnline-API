namespace CatalogOnline_API.Interfaces.Repositories;

using CatalogOnline_API.Models;

public interface IGradeRepository
{
    Task<List<Grade>> GetGradesByStudentAndScienceIdAsync(string studentId, string scienceId);

}
