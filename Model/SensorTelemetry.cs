using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace wickedbotz_web_api.Model;

public class SensorTelemetry
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public int SensorValue { get; set; }
    public Weight SensorWeight { get; set; }
}