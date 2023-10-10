namespace RobotGame.Domain;

public class User
{
    public string? Id { get; set; }
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Email { get; set; } = null!;
    public ICollection<UserLevel> Levels { get; set; } = new List<UserLevel>();
}