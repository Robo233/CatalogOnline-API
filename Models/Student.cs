/// <summary>
/// Represents a student in the CatalogOnline system.
/// </summary>
namespace CatalogOnline_API.Models;

public class Student
{
    /// <summary>
    /// Gets or sets the unique identifier for the student.
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// Gets or sets the student's first name.
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    /// Gets or sets the student's last name.
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the class the student belongs to.
    /// </summary>
    public string? ClassId { get; set; }

    /// <summary>
    /// Gets or sets the list of grade identifiers associated with the student.
    /// </summary>
    public List<string>? GradeIds { get; set; }
}
