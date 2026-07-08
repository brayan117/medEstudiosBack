using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Domain.Entities.constants;

namespace API.Controllers;

[ApiController]
[Route("api/usuarios")]
public class UsuariosController : ControllerBase
{   

    private readonly UsuariosService _usuariosService;

    public UsuariosController(UsuariosService usuariosService)
    {
        _usuariosService = usuariosService;
    }

    [Authorize(Roles = Roles.ADMIN)]
    [HttpGet]
    public async Task<IActionResult> GetAllUsersAsync()
    {
        var usuarios = await _usuariosService.GetAll();
        return Ok(usuarios);
    }
    
}