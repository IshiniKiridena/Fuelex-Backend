using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace Fuelex_Backend.Models.LoginModel
{
    [BsonIgnoreExtraElements]
    public class Login
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { set; get; } = string.Empty;

        [BsonElement("username")]
        public string Username { set; get; } = string.Empty;

        [BsonElement("password")]
        public string Password { set; get; } = string.Empty;
    }
}
