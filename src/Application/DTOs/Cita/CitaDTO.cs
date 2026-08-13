namespace Application.DTOs;

public class CitaDTO{
    public int paciente_id {get; set;}
    public int medico_solicitante_id {get; set;}
    public int tipo_estudio_id {get; set;}
    public DateTime fecha_solicitud {get; set;}
    public DateTime fecha_programada {get; set;}
    public int estado_id {get; set;}
    public string prioridad {get; set;}

    public string notas_procedimiento {get; set;}
}