using Microsoft.AspNetCore.Mvc;
using Application.Interfaces.Services;
using Application.DTOs.Filtros;
using Microsoft.AspNetCore.Authorization;
using Domain.Entities.constants;

namespace API.Controllers;

[ApiController]
[Route("api/auditorias")]
[Authorize(Roles = Roles.ADMIN)]
public class AuditoriasController : ControllerBase
{
    private readonly IAuditoriaService _auditoriaService;

    public AuditoriasController(IAuditoriaService auditoriaService)
    {
        _auditoriaService = auditoriaService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var auditorias = await _auditoriaService.GetAllAuditoriasAsync();
        return Ok(auditorias);
    }

    [HttpGet("paginado")]
    public async Task<IActionResult> GetPaginatedAsync([FromQuery] AuditoriasFiltroDTO filtro)
    {
        var resultado = await _auditoriaService.GetPaginated(filtro);
        return Ok(resultado);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var auditoria = await _auditoriaService.GetAuditoriaByIdAsync(id);
        if (auditoria == null)
            return NotFound();
        return Ok(auditoria);
    }

    [HttpGet("por-fechas")]
    public async Task<IActionResult> GetByFechasAsync(
        [FromQuery] DateTime fechaInicio,
        [FromQuery] DateTime fechaFin)
    {
        var auditorias = await _auditoriaService.GetAuditoriasByFechasAsync(fechaInicio, fechaFin);
        return Ok(auditorias);
    }
}
