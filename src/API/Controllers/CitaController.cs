using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Application.DTOs;
using Application.DTOs.Cita;
using Application.UseCases;
using Domain.Entities.constants;

namespace API.Controllers;

[ApiController]
[Route("api/citas")]
public class CitaController : ControllerBase
{
    private readonly CrearEstudioCitaUseCase _crearEstudioCitaUseCase;
    private readonly ObtenerCitasEstudioUseCase _obtenerCitasEstudioUseCase;
    private readonly EliminarAgendaUseCase _eliminarAgendaUseCase;

    public CitaController(
        CrearEstudioCitaUseCase crearEstudioCitaUseCase,
        ObtenerCitasEstudioUseCase obtenerCitasEstudioUseCase,
        EliminarAgendaUseCase eliminarAgendaUseCase)
    {
        _crearEstudioCitaUseCase = crearEstudioCitaUseCase;
        _obtenerCitasEstudioUseCase = obtenerCitasEstudioUseCase;
        _eliminarAgendaUseCase = eliminarAgendaUseCase;
    }

    [HttpPost]
    [Authorize(Roles = Roles.ADMINISTRATIVO)]
    public async Task<IActionResult> CrearEstudio(CitaDTO cita)
    {
        CitaDTO result =
            await _crearEstudioCitaUseCase
                .CrearEstudioCitaAsync(cita);

        return Ok(result);
    }

    [HttpGet]
    [Authorize(Roles = Roles.ADMINISTRATIVO)]
    public async Task<IActionResult> ObtenerCitas(
        [FromQuery] DateTime fechaInicio,
        [FromQuery] DateTime fechaFin)
    {
        List<ObtenerCitaDTO> result =
            await _obtenerCitasEstudioUseCase
                .ObtenerPorRangoAsync(fechaInicio, fechaFin);

        return Ok(result);
    }

    [HttpDelete("{idAgenda}/estudio/{idEstudio}")]
    [Authorize(Roles = Roles.ADMINISTRATIVO)]
    public async Task<IActionResult> EliminarCita(int idAgenda, int idEstudio)
    {
        bool result =
            await _eliminarAgendaUseCase
                .EliminarCitaAsync(idAgenda, idEstudio);

        return Ok(result);
    }
}