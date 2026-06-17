using Microsoft.AspNetCore.Mvc;
using TraineeManagement.Dtos;
using TraineeManagement.Services;
namespace TraineeManagement.Controllers;
using Microsoft.AspNetCore.Identity;


[ApiController]
[Route("/api/auth")]
public class AuthController : ControllerBase
{

    public IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest loginRequest) 
    {
        LoginResponse loginResponse = await _authService.Login(loginRequest);
        return Ok(loginResponse);
    }
}
