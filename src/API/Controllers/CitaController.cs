using Microsoft.AspNetCore.Mvc;
using Application.DTOs;
using Application.UseCases;

namespace API.Controllers;

[ApiController]
[Route("api/citas")]
public class CitaController : ControllerBase
{
    private readonly CrearEstudioCitaUseCase _crearEstudioCitaUseCase;

    public CitaController(
        CrearEstudioCitaUseCase crearEstudioCitaUseCase)
    {
        _crearEstudioCitaUseCase = crearEstudioCitaUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> CrearEstudio(CitaDTO cita)
    {
        CitaDTO result =
            await _crearEstudioCitaUseCase
                .CrearEstudioCitaAsync(cita);

        return Ok(result);
    }
}