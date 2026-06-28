using Microsoft.AspNetCore.Mvc;
using Infrastructure.Repositories;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers;

[ApiController]
[Route("api/dev")]
public class DevController : ControllerBase
{
    private readonly ITiposUsuariosRepository _tiposUsuariosRepository;

    public DevController(ITiposUsuariosRepository tiposUsuariosRepository)
    {
        _tiposUsuariosRepository = tiposUsuariosRepository;
    }

    [HttpGet("hash")]
    public IActionResult Hash(string password)
    {
        var hash = BCrypt.Net.BCrypt.HashPassword(password);
        return Ok(hash);
    }

    
    [HttpGet("tipoUsuario/{id}")]
    public async Task<IActionResult> TipoUsuario([FromRoute] int id){
        var tipo = await _tiposUsuariosRepository.GetTipoUsuarioByIdAsync(id);
        return Ok(tipo);
    }
}