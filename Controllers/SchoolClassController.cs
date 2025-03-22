using CatalogOnline_API.Interfaces.Repositories;
using CatalogOnline_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatalogOnline_API.Controllers;

[ApiController]
[Route("api/[controller]")]
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
        return Ok(classes);
    }
}
