namespace CatalogOnline_API.Interfaces.Repositories;

using CatalogOnline_API.Models;

public interface IStudentRepository
{
    Task<List<Student>> GetStudentsByClassIdAsync(string classId);
}
