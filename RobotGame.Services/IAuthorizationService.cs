using RobotGame.Domain;

namespace RobotGame.Services;

public interface IAuthorizationService
{
    public Task<string?> Login(User user);
    public Task<string?> Register(User user);
}