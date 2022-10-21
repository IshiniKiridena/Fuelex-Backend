using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Fuelex_Backend.Models.CountModel
{
    [BsonIgnoreExtraElements]
    public class CountModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { set; get; } = string.Empty;

        [BsonElement("status")]
        public string Status { set; get; } = string.Empty;
    }
}
