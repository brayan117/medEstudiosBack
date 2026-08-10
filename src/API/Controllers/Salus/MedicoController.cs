using Application.Interfaces.Services.Salus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Domain.Entities.constants;


namespace API.Controllers.Salus;

[ApiController]
[Route("api/salus/medicos")]
[Authorize(Roles = Roles.ADMIN + "," + Roles.ADMINISTRATIVO)]
public class MedicoController : ControllerBase
{
    private readonly IMedicoService _medicoService;

    public MedicoController(IMedicoService medicoService)
    {
        _medicoService = medicoService;
    }

    [HttpGet("nombre/{nombre}")]
    public async Task<IActionResult> GetMedicoByName(string nombre)
    {
        var medico = await _medicoService.GetMedicoByNameAsync(nombre);
        return Ok(medico);
    }
    
    
}