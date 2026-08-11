namespace Domain.Entities;

public class Estudio
{
    public int Id {get; set;}
    public int paciente_id {get; set;}
    public int medico_solicitante_id {get; set;}
    public int? tecnico_principal_id {get; set;}
    public int tipo_estudio_id {get; set;}
    public DateTime fecha_solicitud {get; set;}
    public int estado_id {get; set;}
    public string? motivo_estudio {get; set;}
    public string? observaciones {get; set;}
    public string prioridad {get; set;}
}