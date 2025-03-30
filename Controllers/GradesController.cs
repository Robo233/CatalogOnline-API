using CatalogOnline_API.Interfaces.Repositories;
using CatalogOnline_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatalogOnline_API.Controllers;

[ApiController]
[Route("api/school-classes")]
public class GradesController : ControllerBase
{
    private readonly IStudentRepository _studentRepository;
    private readonly IGradeRepository _gradeRepository;
    private readonly IScienceRepository _scienceRepository;

    public GradesController(IStudentRepository studentRepository, IGradeRepository gradeRepository, IScienceRepository scienceRepository)
    {
        _studentRepository = studentRepository;
        _gradeRepository = gradeRepository;
        _scienceRepository = scienceRepository;
    }

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
