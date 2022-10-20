using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Fuelex_Backend.Models.CustomerModel
{
    [BsonIgnoreExtraElements]
    public class CustomerModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { set; get; } = string.Empty;

        [BsonElement("userName")]
        public string UserName { set; get; } = string.Empty;

        [BsonElement("password")]
        public string Password { set; get; } = string.Empty;

        [BsonElement("fullName")]
        public string FullName { set; get; } = string.Empty;

        [BsonElement("nic")]
        public string Nic { set; get; } = string.Empty;

        [BsonElement("vehicleType")]
        public string VehicleType { set; get; } = string.Empty;

        [BsonElement("vehicleNumber")]
        public string VehicleNumber { set; get; } = string.Empty;

    }
}
