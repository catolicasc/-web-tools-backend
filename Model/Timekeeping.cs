namespace wickedbotz_web_api.Model;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Timekeeping
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public int TopSpeed { get; set; }
    public int Threshold { get; set; }
    public int InverseMaximum { get; set; }
    public int ProportionalSpeed { get; set; }
    public int Speed { get; set; }
    public int BreakingTime { get; set; }
    public List<SensorTelemetry> SensorTelemetries { get; set; }

}