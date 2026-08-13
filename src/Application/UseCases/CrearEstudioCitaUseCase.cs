using Domain.Entities;
using Application.DTOs;
using Application.Mappers;
using Application.Interfaces.Services;

namespace Application.UseCases;

public  class CrearEstudioCitaUseCase
{
    private readonly IEstudioService _EstudioService;

    public CrearEstudioCitaUseCase(IEstudioService estudioService){
        _EstudioService = estudioService;
    }

    public async Task<CitaDTO> CrearEstudioCitaAsync(CitaDTO cita){
        Estudio estudio = await _EstudioService.CrearEstudioAsync(
            CitaMapper.CitaDTOToEstudio(cita)
        );
        return cita;
    }
}
