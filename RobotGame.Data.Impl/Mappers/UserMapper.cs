using AutoMapper;
using RobotGame.Data.Entities;

namespace RobotGame.Data.Impl.Mappers;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<User, Domain.User>();
        CreateMap<Domain.User, User>();
    }
}