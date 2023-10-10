using AutoMapper;
using RobotGame.Domain;
using RobotGame.Dto;

namespace RobotGame.Mappers;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<UserDto, User>();
        CreateMap<User, UserDto>();
    }
}