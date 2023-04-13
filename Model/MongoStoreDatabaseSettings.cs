namespace wickedbotz_web_api.Model;

public class MongoStoreDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string MongoCollectionName { get; set; } = null!;
}
