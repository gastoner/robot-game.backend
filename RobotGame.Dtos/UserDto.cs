namespace RobotGame.Dto;

public class UserDto
{
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string? Email { get; set; }
    public ICollection<UserLevelDto> Levels { get; set; } = new List<UserLevelDto>();
}