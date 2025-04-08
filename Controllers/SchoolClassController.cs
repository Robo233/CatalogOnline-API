/// <summary>
/// API controller for handling school class-related requests.
/// </summary>
using CatalogOnline_API.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CatalogOnline_API.Controllers;

[ApiController]
[Route("api/school-classes")]
public class SchoolClassController : ControllerBase
{
    /// <summary>
    /// Repository for performing school class data operations.
    /// </summary>
    private readonly ISchoolClassRepository _schoolClassRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="SchoolClassController"/> class with the specified school class repository.
    /// </summary>
    /// <param name="schoolClassRepository">The school class repository.</param>
    public SchoolClassController(ISchoolClassRepository schoolClassRepository)
    {
        _schoolClassRepository = schoolClassRepository;
    }

    /// <summary>
    /// Retrieves all school classes.
    /// </summary>
    /// <returns>An IActionResult containing the list of school classes.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAllSchoolClasses()
    {
        var classes = await _schoolClassRepository.GetSchoolClassesAsync();

        var classesWithoutScienceIds = classes.Select(c => new
        {
            c.Id,
            c.Year,
            c.Name
        }).ToList();

        return Ok(classesWithoutScienceIds);
    }
}
