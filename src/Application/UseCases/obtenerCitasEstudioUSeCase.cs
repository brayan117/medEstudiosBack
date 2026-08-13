using Domain.Entities;
using Application.DTOs.Cita;
using Application.Mappers;
using Application.Interfaces.Repositories;
using Application.Interfaces.Repositories.Salus;

namespace Application.UseCases;

public class ObtenerCitasEstudioUseCase
{
    private readonly IAgendaRepository _agendaRepository;
    private readonly IEstudiosRepository _estudioRepository;
    private readonly IEstadoEstudioRepository _estadoEstudioRepository;
    private readonly IMedicoRepository _medicoRepository;
    private readonly IProcedimientoRepository _procedimientoRepository;
    private readonly IAfiliadoRepository _afiliadoRepository;

    public ObtenerCitasEstudioUseCase(
        IAgendaRepository agendaRepository,
        IEstudiosRepository estudioRepository,
        IEstadoEstudioRepository estadoEstudioRepository,
        IMedicoRepository medicoRepository,
        IProcedimientoRepository procedimientoRepository,
        IAfiliadoRepository afiliadoRepository)
    {
        _agendaRepository = agendaRepository;
        _estudioRepository = estudioRepository;
        _estadoEstudioRepository = estadoEstudioRepository;
        _medicoRepository = medicoRepository;
        _procedimientoRepository = procedimientoRepository;
        _afiliadoRepository = afiliadoRepository;
    }

    public async Task<List<ObtenerCitaDTO>> ObtenerPorRangoAsync(
        DateTime fechaInicio,
        DateTime fechaFin)
    {
        var agendas = await _agendaRepository.GetAgendasAsyncByDate(fechaInicio, fechaFin);
        if (agendas.Count == 0)
            return new List<ObtenerCitaDTO>();

        var estudioIds = agendas.Select(a => a.estudio_id).Distinct().ToList();
        var estudios = await _estudioRepository.GetEstudiosByIdsAsync(estudioIds);
        var estudioPorId = estudios.ToDictionary(e => e.Id);

        var estadoPorId = (await _estadoEstudioRepository.GetAllAsync())
            .ToDictionary(e => e.Id, e => e.nombre);

        var nombrePacientePorId = await ObtenerNombresAfiliadosAsync(
            estudios.Select(e => e.paciente_id));
        var nombreEstudioPorId = await ObtenerNombresProcedimientosAsync(
            estudios.Select(e => e.tipo_estudio_id));
        var nombreMedicoPorId = await ObtenerNombresMedicosAsync(
            estudios.Select(e => e.medico_solicitante_id));

        var citas = new List<ObtenerCitaDTO>();
        foreach (var agenda in agendas)
        {
            if (!estudioPorId.TryGetValue(agenda.estudio_id, out var estudio))
                continue;

            citas.Add(CitaMapper.AgendaYEstudioAObtenerCitaDTO(
                agenda,
                estudio,
                estadoPorId.GetValueOrDefault(estudio.estado_id) ?? "Desconocido",
                nombrePacientePorId.GetValueOrDefault(estudio.paciente_id) ?? "Sin identificar",
                nombreEstudioPorId.GetValueOrDefault(estudio.tipo_estudio_id) ?? "Sin especificar",
                nombreMedicoPorId.GetValueOrDefault(estudio.medico_solicitante_id) ?? "Sin asignar"));
        }

        return citas;
    }

    private async Task<Dictionary<int, string>> ObtenerNombresAfiliadosAsync(IEnumerable<int> documentoPacientes)
    {
        var result = new Dictionary<int, string>();
        foreach (var documentoPaciente in documentoPacientes.Distinct())
        {
            var afiliado = await _afiliadoRepository
                .GetAfiliadoByDocumentoAsync(documentoPaciente.ToString());
            if (afiliado != null)
                result[documentoPaciente] = $"{afiliado.nom1} {afiliado.ape1}".Trim();
        }
        return result;
    }

    private async Task<Dictionary<int, string>> ObtenerNombresProcedimientosAsync(IEnumerable<int> ids)
    {
        var result = new Dictionary<int, string>();
        foreach (var id in ids.Distinct())
        {
            var procedimiento = await _procedimientoRepository.GetProcedimientoByIdAsync(id);
            if (procedimiento != null)
                result[id] = procedimiento.nom_procedimiento;
        }
        return result;
    }

    private async Task<Dictionary<int, string>> ObtenerNombresMedicosAsync(IEnumerable<int> ids)
    {
        var result = new Dictionary<int, string>();
        foreach (var id in ids.Distinct())
        {
            var medico = await _medicoRepository.GetMedicoByIdAsync(id);
            if (medico != null)
                result[id] = medico.nombres;
        }
        return result;
    }
}
