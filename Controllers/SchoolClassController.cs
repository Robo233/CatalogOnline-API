using CatalogOnline_API.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CatalogOnline_API.Controllers;

[ApiController]
[Route("api/school-classes")]
public class SchoolClassController : ControllerBase
{
    private readonly ISchoolClassRepository _schoolClassRepository;

    public SchoolClassController(ISchoolClassRepository schoolClassRepository)
    {
        _schoolClassRepository = schoolClassRepository;
    }

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
