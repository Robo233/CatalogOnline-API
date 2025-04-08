namespace CatalogOnline_API.Models;

public class Grade
{
    public string? Id { get; set; }
    public string? StudentId { get; set; }
    public string? ScienceId { get; set; }
    public DateTime Date { get; set; }
    public string? GradeValue { get; set; }

}
