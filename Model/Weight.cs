namespace wickedbotz_web_api.Model;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


public class Weight
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public int SensorWeight { get; set; }
}