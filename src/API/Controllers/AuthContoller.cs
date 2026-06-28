using Application.DTOs.Auth;
using Application.Services;
using Microsoft.AspNetCore.Mvc; 
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }


    [HttpPost("login")]
    public async Task<IActionResult> Login(
        LoginRequestDTO request)
    {
        var result = await _authService
            .Login(request);

        if (result == null)
        {
            return Unauthorized(new
            {
                message = "Credenciales inválidas"
            });
        }

        return Ok(result);
    }
}