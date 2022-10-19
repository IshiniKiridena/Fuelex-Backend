using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace Fuelex_Backend.Models.Queue
{
    [BsonIgnoreExtraElements]
    public class Queue
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { set; get; } = string.Empty;

        [BsonElement("location")]
        public string Location { set; get; } = string.Empty;

        [BsonElement("vehicleType")]
        public string VehicleType { set; get; } = string.Empty;

        [BsonElement("currentCount")]
        public int CurrentCount { set; get; }

        [BsonElement("beforeCount")]
        public int BeforeCount { set; get; }

        [BsonElement("afterCount")]
        public int AfterCount { set; get; }
    }
}
