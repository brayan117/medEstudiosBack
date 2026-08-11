using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Domain.Entities.constants;
using Application.Services.Salus;
using Application.DTOs.Salus.Procedimiento;
using Application.Interfaces.Services.Salus;


namespace API.Controllers.Salus;

[ApiController]
[Route("api/salus/procedimientos")]
[Authorize(Roles = Roles.ADMINISTRATIVO)]
public class ProcedimientoController : ControllerBase
{
    private readonly IProcedimientoService _procedimientoService;

    public ProcedimientoController(IProcedimientoService procedimientoService)
    {
        _procedimientoService = procedimientoService;
    }

    [HttpPost("buscar")]
    public async Task<IActionResult> ObtenerProcedimientos([FromBody] ProcedimientoBusquedaRequestDTO request)
    {
        var procedimientos = await _procedimientoService.GetProcedimientosAsync(request);

        if (procedimientos == null || procedimientos.Count == 0)
        {
            return NotFound();
        }

        return Ok(procedimientos);
    }
}
