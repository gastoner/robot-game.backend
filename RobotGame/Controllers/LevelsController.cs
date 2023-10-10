using Microsoft.AspNetCore.Mvc;

namespace RobotGame.Controllers;

[ApiController]
[Route("[controller]")]
public class LevelsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetLevel()
    {
        return Ok(User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value);
    }
}

