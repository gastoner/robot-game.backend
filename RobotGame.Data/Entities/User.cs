using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RobotGame.Data.Entities;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Email { get; set; } = null!;
    public ICollection<UserLevel> Levels { get; set; } = new List<UserLevel>();

}

public class UserLevel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? LevelId { get; set; }

    public double Score { get; set; }
}