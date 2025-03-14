using InterviewPrep.Core.DTOs.Identity.Login;
using InterviewPrep.Core.DTOs.Identity.Register;
using InterviewPrep.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InterviewPrep.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    public IAuthService _authService;
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<LoginServiceResponseDto>> Register([FromBody] Register user)
    {
        var res = await _authService.Register(user);

        if (res is not null)
            return Ok(user);

        return BadRequest();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] Login login)
    {
        try
        {
            var response = await _authService.Login(login);
            return Ok(response);
        }
        catch (UnauthorizedAccessException ex)
        {
            if (ex.Message.Contains("locked"))
            {
                return Unauthorized(new { message = "Your account is locked. Please try again after 15 min." });
            }
            return Unauthorized(new { message = ex.Message });
        }
    }
}