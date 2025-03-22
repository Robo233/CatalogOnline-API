namespace CatalogOnline_API.Models;

public class SchoolClass
{
    public string? Id { get; set; }
    public int Year { get; set; }
    public string? Name { get; set; }
    public List<string>? ScienceIds { get; set; }
}
