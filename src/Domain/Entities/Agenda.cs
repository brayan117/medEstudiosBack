namespace Domain.Entities;

public class Agenda
{
    public int id { get; set; }
    public int estudio_id { get; set; }
    public DateTime fecha_programada { get; set; }
    public TimeSpan? fecha_inicio_real { get; set; }
    public TimeSpan? fecha_fin_real { get; set; }           
    public int? duracion_estimada { get; set; }
    public string? notas_procedimiento { get; set; }
}
