/// <summary>
/// API controller for handling student-related requests.
/// </summary>
using CatalogOnline_API.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CatalogOnline_API.Controllers;

[ApiController]
[Route("api/students")]
public class StudentController : ControllerBase
{
    /// <summary>
    /// Repository for performing student data operations.
    /// </summary>
    private readonly IStudentRepository _studentRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="StudentController"/> class with the specified student repository.
    /// </summary>
    /// <param name="studentRepository">The student repository.</param>
    public StudentController(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    /// <summary>
    /// Retrieves students belonging to a specific school class.
    /// </summary>
    /// <param name="classId">The ID of the school class.</param>
    /// <returns>An IActionResult containing the list of students or a NotFound result if none are found.</returns>
    [HttpGet("school-classes/{classId}")]
    public async Task<IActionResult> GetStudentsFromSchoolClass(string classId)
    {
        var students = await _studentRepository.GetStudentsByClassIdAsync(classId);

        if (students == null || students.Count == 0)
        {
            return NotFound($"No students found in class with ID: {classId}");
        }

        var studentsWithoutClassId = students.Select(s => new
        {
            s.Id,
            s.FirstName,
            s.LastName
        }).ToList();

        return Ok(studentsWithoutClassId);
    }
}
