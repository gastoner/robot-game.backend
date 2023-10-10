using AutoMapper;
using MongoDB.Driver;
using RobotGame.Domain;

namespace RobotGame.Data.Impl;

public class UserRepository: IUserRepository
{
    private readonly IMongoCollection<Entities.User> _users;
    private readonly IMapper _mapper;
    public UserRepository(IRepositoryBase repositoryBase, IMapper mapper)
    {
        _users = repositoryBase.GetDatabase().GetCollection<Entities.User>("Users");
        _mapper = mapper;
    }


    public async Task<User?> Get(string username)
    {
        var entity = (await _users.FindSync(u => u.UserName == username).ToListAsync()).FirstOrDefault();
        return entity != null ? _mapper.Map<User>(entity) : null;
    }

    public async Task<string> Create(User user)
    {
        var entity = _mapper.Map<Entities.User>(user);
        await _users.InsertOneAsync(entity);
        return entity.Id!;
    }
}