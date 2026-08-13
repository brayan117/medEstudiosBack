using Domain.Entities;
using Application.DTOs;
using Application.DTOs.Cita;

namespace Application.Mappers;

public static class CitaMapper {

    public static Estudio CitaDTOToEstudio (CitaDTO cita){

        return new Estudio {
            paciente_id = cita.paciente_id,
            medico_solicitante_id = cita.medico_solicitante_id,
            tipo_estudio_id = cita.tipo_estudio_id,
            fecha_solicitud = cita.fecha_solicitud,
            fecha_programada = cita.fecha_programada,
            estado_id = cita.estado_id,
            prioridad = cita.prioridad
        };
    }

    public static Agenda CitaDTOToAgenda (CitaDTO cita){

        return new Agenda {
            fecha_programada = cita.fecha_programada,
            notas_procedimiento = cita.notas_procedimiento
        };
    }

    public static ObtenerCitaDTO AgendaYEstudioAObtenerCitaDTO (
        Agenda agenda,
        Estudio estudio,
        string estado,
        string nombrePaciente,
        string nombreEstudio,
        string nombreMedico)
    {
        return new ObtenerCitaDTO
        {
            id_agenda = agenda.id,
            id_estudio = estudio.Id,
            fecha_programada = agenda.fecha_programada,
            estado = estado,
            nombre_paciente = nombrePaciente,
            nombre_estudio = nombreEstudio,
            nombre_medico = nombreMedico,
            prioridad = estudio.prioridad,
            notas_procedimiento = agenda.notas_procedimiento
        };
    }

}