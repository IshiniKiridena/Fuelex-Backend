using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace Fuelex_Backend.Models.FuelTypeModel
{
    [BsonIgnoreExtraElements]
    public class FuelTypeModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { set; get; } = string.Empty;

        [BsonElement("location")]
        public string Location { set; get; } = string.Empty;

        [BsonElement("type")]
        public string Type { set; get; } = string.Empty;

        [BsonElement("status")]
        public bool Status { set; get; }

        [BsonElement("quantity")]
        public int Quantity { set; get; }

        [BsonElement("arrivalTime")]
        public string ArrivalTime { set; get; } = string.Empty;

        [BsonElement("finishTime")]
        public string FinishTime { set; get; } = string.Empty;
    }
}
