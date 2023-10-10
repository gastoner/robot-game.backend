using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RobotGame.Data;
using RobotGame.Domain;
using RobotGame.Domain.Settings;

namespace RobotGame.Services.Impl;

public class AuthorizationService : IAuthorizationService
{
    private readonly IUserRepository _userRepository;
    private readonly JwtSettings _jwtSettings;
    public AuthorizationService(IUserRepository userRepository, IOptions<JwtSettings> jwtSettings)
    {
        _userRepository = userRepository;
        _jwtSettings = jwtSettings.Value;
    }

    public async Task<string?> Login(User user)
    {
        var userDb = await _userRepository.Get(user.UserName);
        if (userDb == null) return null;

        return user.Password == userDb.Password ? GenerateToken(userDb.Id!) : null;
    }

    public async Task<string?> Register(User user)
    {
        var userDb = await _userRepository.Get(user.UserName);
        if (userDb != null) return null;

        var id = await _userRepository.Create(user);
        return GenerateToken(id);
    }

    private string GenerateToken(string id)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[] {
            new Claim("Id", id)
        };

        var token = new JwtSecurityToken(
            _jwtSettings.Issuer,
            _jwtSettings.Issuer,
            claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}