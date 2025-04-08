/// <summary>
/// Represents a school class in the CatalogOnline system.
/// </summary>
namespace CatalogOnline_API.Models;

public class SchoolClass
{
    /// <summary>
    /// Gets or sets the unique identifier for the school class.
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// Gets or sets the academic year of the school class.
    /// </summary>
    public int Year { get; set; }

    /// <summary>
    /// Gets or sets the name of the school class.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the list of science subject identifiers associated with the class.
    /// </summary>
    public List<string>? ScienceIds { get; set; }
}
