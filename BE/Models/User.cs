// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;



public class User
{
    [BsonId]
    public ObjectId _Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Status { get; set; }
    public string UserType { get; set; }
    public string Avatar { get; set; }
    public string RoleName { get; set; }
}
