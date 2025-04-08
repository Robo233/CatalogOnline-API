/// <summary>
/// API controller for handling grade-related requests.
/// </summary>
using CatalogOnline_API.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CatalogOnline_API.Controllers;

[ApiController]
[Route("api/school-classes")]
public class GradesController : ControllerBase
{
    /// <summary>
    /// Repository for performing student data operations.
    /// </summary>
    private readonly IStudentRepository _studentRepository;

    /// <summary>
    /// Repository for performing grade data operations.
    /// </summary>
    private readonly IGradeRepository _gradeRepository;

    /// <summary>
    /// Repository for performing science data operations.
    /// </summary>
    private readonly IScienceRepository _scienceRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GradesController"/> class with the specified repositories.
    /// </summary>
    /// <param name="studentRepository">The student repository.</param>
    /// <param name="gradeRepository">The grade repository.</param>
    /// <param name="scienceRepository">The science repository.</param>
    public GradesController(IStudentRepository studentRepository, IGradeRepository gradeRepository, IScienceRepository scienceRepository)
    {
        _studentRepository = studentRepository;
        _gradeRepository = gradeRepository;
        _scienceRepository = scienceRepository;
    }

    /// <summary>
    /// Retrieves grades for a specific student and science subject.
    /// </summary>
    /// <param name="studentId">The student's unique ID.</param>
    /// <param name="scienceId">The science subject's unique ID.</param>
    /// <returns>An IActionResult containing the list of grades or a NotFound result if none are found.</returns>
    [HttpGet("grades/{studentId}/{scienceId}")]
    public async Task<IActionResult> GetGradesByStudentAndScienceId(string studentId, string scienceId)
    {
        var grades = await _gradeRepository.GetGradesByStudentAndScienceIdAsync(studentId, scienceId);

        if (grades == null || grades.Count == 0)
        {
            return NotFound($"No grades found with student id: {studentId} and science id: {scienceId}");
        }

        var science = await _scienceRepository.GetScienceByIdAsync(scienceId);
        var scienceName = science?.Name;

        var gradesWithScienceName = grades.Select(g => new
        {
            g.Id,
            ScienceName = scienceName,
            g.Date,
            g.GradeValue
        }).ToList();

        return Ok(gradesWithScienceName);
    }
}
