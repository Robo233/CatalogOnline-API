/// <summary>
/// API controller for handling science-related requests.
/// </summary>
using CatalogOnline_API.Interfaces.Repositories;
using CatalogOnline_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatalogOnline_API.Controllers;

[ApiController]
[Route("api/students")]
public class ScienceController : ControllerBase
{
    /// <summary>
    /// Repository for performing science data operations.
    /// </summary>
    private readonly IScienceRepository _scienceRepository;

    /// <summary>
    /// Repository for performing school class data operations.
    /// </summary>
    private readonly ISchoolClassRepository _schoolClassRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="ScienceController"/> class with the specified science and school class repositories.
    /// </summary>
    /// <param name="scienceRepository">The science repository.</param>
    /// <param name="schoolClassRepository">The school class repository.</param>
    public ScienceController(IScienceRepository scienceRepository, ISchoolClassRepository schoolClassRepository)
    {
        _scienceRepository = scienceRepository;
        _schoolClassRepository = schoolClassRepository;
    }

    /// <summary>
    /// Retrieves science subjects associated with a specific school class.
    /// </summary>
    /// <param name="classId">The ID of the school class.</param>
    /// <returns>An IActionResult containing the list of science subjects or a NotFound result if the class is not found.</returns>
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
