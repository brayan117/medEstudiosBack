using Application.Interfaces.Services.Salus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Domain.Entities.constants;


namespace API.Controllers.Salus;

[ApiController]
[Route("api/salus/afiliados")]
[Authorize(Roles = Roles.ADMIN + "," + Roles.ADMINISTRATIVO)]
public class AfiliadosController : ControllerBase
{
    private readonly IAfiliadoService _afiliadoService;

    public AfiliadosController(IAfiliadoService afiliadoService)
    {
        _afiliadoService = afiliadoService;
    }
    
    [HttpGet("documento/{documento}")]
    public async Task<IActionResult> GetAfiliadoByDocumento(string documento)
    {
        var afiliado = await _afiliadoService.GetAfiliadoByDocumentoAsync(documento);
        if (afiliado == null)
        {
            return NotFound();
        }
        return Ok(afiliado);
    }
}
