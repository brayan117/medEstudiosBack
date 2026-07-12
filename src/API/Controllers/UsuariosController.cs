using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DTOs.Filtros;
using Microsoft.AspNetCore.Authorization;
using Domain.Entities.constants;
using Application.DTOs.usuarios;

namespace API.Controllers;

[ApiController]
[Route("api/usuarios")]
public class UsuariosController : ControllerBase
{   

    private readonly IUsuariosService _usuariosService;

    public UsuariosController(IUsuariosService usuariosService)
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
    [HttpGet("paginado")]
    public async Task<IActionResult> GetPaginatedAsync([FromQuery] UsuariosFiltroDTO filtro)
    {
        var resultado = await _usuariosService.GetPaginated(filtro);
        return Ok(resultado);
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

    [Authorize(Roles = Roles.ADMIN)]
    [HttpDelete("{userId}")]
    public async Task<IActionResult> DeleteUserAsync(int userId)
    {
        var result = await _usuariosService.DeleteUserAsync(userId);
        return Ok(result);
    }
      
}