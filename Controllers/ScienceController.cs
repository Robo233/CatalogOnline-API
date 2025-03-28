using CatalogOnline_API.Interfaces.Repositories;
using CatalogOnline_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatalogOnline_API.Controllers;

[ApiController]
[Route("api/students")]
public class ScienceController : ControllerBase
{
    private readonly IScienceRepository _scienceRepository;
    private readonly ISchoolClassRepository _schoolClassRepository;

    public ScienceController(IScienceRepository scienceRepository, ISchoolClassRepository schoolClassRepository)
    {
        _scienceRepository = scienceRepository;
        _schoolClassRepository = schoolClassRepository;
    }

    [HttpGet("sciences/{classId}")]
    public async Task<IActionResult> GetSciencesFromSchoolClass(string classId)
    {
        var schoolClass = await _schoolClassRepository.GetSchoolClassByIdAsync(classId);

        if (schoolClass == null)
        {
            return NotFound($"School class with ID '{classId}' not found.");
        }

        if (schoolClass.ScienceIds == null || !schoolClass.ScienceIds.Any())
        {
            return Ok(new List<Science>());
        }

        var sciences = await _scienceRepository.GetSciencesByIdsAsync(schoolClass.ScienceIds);

        return Ok(sciences);
    }
}