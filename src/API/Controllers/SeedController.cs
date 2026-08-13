using Microsoft.AspNetCore.Mvc;
using Application.Interfaces.Services;

namespace API.Controllers;

[ApiController]
[Route("api/seed")]
public class SeedController : ControllerBase
{
    private readonly IEstadoEstudioService _estadoEstudioService;

    public SeedController(IEstadoEstudioService estadoEstudioService)
    {
        _estadoEstudioService = estadoEstudioService;
    }

    [HttpPost("estados")]
    public async Task<IActionResult> InicializarEstados()
    {
        await _estadoEstudioService.InicializarEstadosAsync();
        return Ok(new { message = "Estados inicializados correctamente" });
    }
}
