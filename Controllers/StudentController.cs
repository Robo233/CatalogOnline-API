using CatalogOnline_API.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CatalogOnline_API.Controllers;

[ApiController]
[Route("api/students")]
public class StudentController : ControllerBase
{
    private readonly IStudentRepository _studentRepository;

    public StudentController(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    [HttpGet("school-classes/{classId}")]
    public async Task<IActionResult> GetStudentsFromSchoolClass(string classId)
    {
        var students = await _studentRepository.GetStudentsByClassIdAsync(classId);

        if (students == null || students.Count == 0)
        {
            return NotFound($"No students found in class with ID: {classId}");
        }

        return Ok(students);
    }
}