using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Domain.Entities.constants;
using Application.DTOs.usuarios;

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

    [Authorize(Roles = Roles.ADMIN)]
    [HttpPut("{userId}/estado")]
    public async Task<IActionResult> UpdateEstadoAsync(int userId, [FromBody] ActualizarEstadoDTO dto)
    {
        var result = await _usuariosService.UpdateEstadoAsync(userId, dto);
        return Ok(result);
    }

    [Authorize(Roles = Roles.ADMIN)]
    [HttpPost]
    public async Task<IActionResult> CreateUserAsync([FromBody] UsuarioRequestDTO dto)
    {
        var result = await _usuariosService.CreateUserAsync(dto);
        return Ok(result);
    }
    
}