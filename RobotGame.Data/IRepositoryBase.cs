using MongoDB.Driver;

namespace RobotGame.Data;

public interface IRepositoryBase
{
    public IMongoDatabase GetDatabase();
}