using CatalogOnline_API.Interfaces.Repositories;
using CatalogOnline_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CatalogOnline_API.Controllers;

[ApiController]
[Route("api/school-classes")]
public class GradesController : ControllerBase
{
    private readonly IGradeRepository _gradeRepository;
    private readonly IScienceRepository _scienceRepository;

    public GradesController(IGradeRepository gradeRepository, IScienceRepository scienceRepository)
    {
        _gradeRepository = gradeRepository;
        _scienceRepository = scienceRepository;
    }

    [HttpGet("grades/{studentId}/{scienceId}")]
    [AllowAnonymous]
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

    [HttpGet("grades/{id}")]
    [Authorize]
    public async Task<IActionResult> GetGradeById(string id)
    {
        var grade = await _gradeRepository.GetGradeByIdAsync(id);
        if (grade == null)
        {
            return NotFound($"Grade with id: {id} not found.");
        }
        return Ok(new { grade.Date, grade.GradeValue });
    }

    [HttpPost("grades")]
    [Authorize]
    public async Task<IActionResult> UpsertGrade([FromBody] Grade grade)
    {
        if (grade == null)
        {
            return BadRequest("Grade data is required.");
        }
        await _gradeRepository.UpsertGradeAsync(grade);
        return Ok("Grade upserted successfully.");
    }

    [HttpDelete("grades/{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteGrade(string id)
    {
        var result = await _gradeRepository.DeleteGradeAsync(id);
        if (!result)
        {
            return NotFound($"Grade with id: {id} not found.");
        }
        return Ok("Grade deleted successfully.");
    }
}
