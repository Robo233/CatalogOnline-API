/// <summary>
/// Represents the configuration settings for connecting to the MongoDB database.
/// </summary>
public class MongoDbSettings
{
    /// <summary>
    /// Gets or sets the connection string for MongoDB.
    /// </summary>
    public string? ConnectionString { get; set; }

    /// <summary>
    /// Gets or sets the name of the MongoDB database.
    /// </summary>
    public string? DatabaseName { get; set; }
}
