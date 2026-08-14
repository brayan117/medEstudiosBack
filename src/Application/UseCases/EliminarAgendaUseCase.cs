using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities.constants;
using Domain.Entities.Constants;

namespace Application.UseCases;

public class EliminarAgendaUseCase
{
    private readonly IAgendaRepository _agendaRepository;
    private readonly IEstudiosRepository _estudioRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuditoriaService _auditoriaService;

    public EliminarAgendaUseCase(
        IAgendaRepository agendaRepository,
        IEstudiosRepository estudioRepository,
        IUnitOfWork unitOfWork,
        IAuditoriaService auditoriaService)
    {
        _agendaRepository = agendaRepository;
        _estudioRepository = estudioRepository;
        _unitOfWork = unitOfWork;
        _auditoriaService = auditoriaService;
    }

    public async Task<bool> EliminarCitaAsync(int idAgenda, int idEstudio)
    {
        await _unitOfWork.BeginTransactionAsync();

        try
        {
            var agenda = await _agendaRepository.GetByIdAsync(idAgenda)
                ?? throw new Exception($"No se encontró la cita de agenda con id {idAgenda}");

            var estudio = await _estudioRepository.GetByIdAsync(idEstudio)
                ?? throw new Exception($"No se encontró el estudio con id {idEstudio}");

            if (agenda.estudio_id != idEstudio)
                throw new Exception("La agenda y el estudio no corresponden a la misma cita");

            await _agendaRepository.DeleteAsync(agenda);
            await _estudioRepository.DeleteAsync(estudio);

            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitTransactionAsync();

            await _auditoriaService.CrearAuditoria(
                accion: AuditoriaAcciones.ELIMINAR,
                tabla: Tablas.AGENDA_ESTUDIOS,
                idRegistro: idAgenda,
                descripcion: $"Cita eliminada (agenda {idAgenda}, estudio {idEstudio})");

            return true;
        }
        catch
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }
}
