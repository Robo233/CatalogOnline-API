/// <summary>
/// Represents a grade assigned to a student for a specific science subject.
/// </summary>
namespace CatalogOnline_API.Models;

public class Grade
{
    /// <summary>
    /// Gets or sets the unique identifier for the grade record.
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the student associated with the grade.
    /// </summary>
    public string? StudentId { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the science subject associated with the grade.
    /// </summary>
    public string? ScienceId { get; set; }

    /// <summary>
    /// Gets or sets the date when the grade was assigned.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets or sets the value of the grade.
    /// </summary>
    public string? GradeValue { get; set; }
}
