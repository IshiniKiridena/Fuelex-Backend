using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace Fuelex_Backend.Models.FuelStation
{
    [BsonIgnoreExtraElements]
    public class FuelStation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { set; get; } = string.Empty;

        [BsonElement("location")]
        public string Location { set; get; } = string.Empty;

        [BsonElement("userName")]
        public string UserName { set; get; } = string.Empty;

        [BsonElement("password")]
        public string Password { set; get; } = string.Empty;
    }
}
