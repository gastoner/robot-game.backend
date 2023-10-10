using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RobotGame.Domain;
using RobotGame.Dto;
using IAuthorizationService = RobotGame.Services.IAuthorizationService;

namespace RobotGame.Controllers;

[AllowAnonymous]
[ApiController]
[Route("[controller]")]
public class AuthorizationController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IAuthorizationService _authorizationService;

    public AuthorizationController(IMapper mapper, IAuthorizationService authorizationService)
    {
        _mapper = mapper;
        _authorizationService = authorizationService;
    }

    [HttpPut]
    public async Task<IActionResult> Login([FromBody] UserDto userDto)
    {
        var token = await _authorizationService.Login(_mapper.Map<User>(userDto));
        return token == null ? NoContent() : Ok(token);
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] UserDto userDto)
    {
        var token = await _authorizationService.Register(_mapper.Map<User>(userDto));
        return token == null ? NoContent() : Ok(token);
    }
}

