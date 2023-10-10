using RobotGame.Domain;

namespace RobotGame.Data;

public interface IUserRepository
{
    Task<User?> Get(string username);
    Task<string> Create(User user);
}