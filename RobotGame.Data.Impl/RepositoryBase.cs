using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RobotGame.Domain.Settings;

namespace RobotGame.Data.Impl;

public class RepositoryBase : IRepositoryBase
{
    private readonly IMongoDatabase _database;
    public RepositoryBase(IOptions<DatabaseSettings> databaseSettings)
    {
        var client = new MongoClient(databaseSettings.Value.ConnectionString);
        _database = client.GetDatabase(databaseSettings.Value.DatabaseName);

        var collections = _database.ListCollectionNames().ToList();
        if (!collections.Contains("Users"))
        {
            _database.CreateCollection("Users");
        }
    }

    public IMongoDatabase GetDatabase()
    {
        return _database;
    }
}