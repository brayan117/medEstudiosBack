using Domain.Entities;
using Application.DTOs;
using Application.Mappers;
using Application.Interfaces;
using Application.Interfaces.Services;
using Application.Interfaces.Repositories;
using Domain.Entities.constants;
using Domain.Entities.Constants;

namespace Application.UseCases;

public class CrearEstudioCitaUseCase
{
    private readonly IEstudioService _estudioService;
    private readonly IAgendaService _agendaService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuditoriaService _auditoriaService;

    public CrearEstudioCitaUseCase(
        IEstudioService estudioService,
        IAgendaService agendaService,
        IUnitOfWork unitOfWork,
        IAuditoriaService auditoriaService)
    {
        _estudioService = estudioService;
        _agendaService = agendaService;
        _unitOfWork = unitOfWork;
        _auditoriaService = auditoriaService;
    }

    public async Task<CitaDTO> CrearEstudioCitaAsync(CitaDTO cita)
    {
        await _unitOfWork.BeginTransactionAsync();

        try
        {
            // 1. Crear estudio
            Estudio estudio = await _estudioService.CrearEstudioAsync(
                CitaMapper.CitaDTOToEstudio(cita)
            );

            // 2. Guardar para obtener el ID generado
            await _unitOfWork.SaveChangesAsync();

            // 3. Crear agenda utilizando el ID del estudio
            Agenda agenda = CitaMapper.CitaDTOToAgenda(cita);

            agenda.estudio_id = estudio.Id;

            // 4. Guardar agenda
            await _agendaService.CrearAgendaAsync(agenda);

            await _unitOfWork.SaveChangesAsync();

            // 5. Confirmar transacción
            await _unitOfWork.CommitTransactionAsync();

            // Crear auditoría
            await _auditoriaService.CrearAuditoria(
                accion: AuditoriaAcciones.CREAR,
                tabla: Tablas.ESTUDIOS,
                idRegistro: estudio.Id,
                descripcion: $"Estudio creado para paciente {cita.paciente_id}, médico {cita.medico_solicitante_id}, tipo estudio {cita.tipo_estudio_id}"
            );

            return cita;
        }
        catch
        {
            // Si falla estudio o agenda,
            // se deshace toda la transacción
            await _unitOfWork.RollbackTransactionAsync();

            throw;
        }
    }
}