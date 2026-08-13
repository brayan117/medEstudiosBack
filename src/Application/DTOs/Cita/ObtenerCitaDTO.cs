namespace Application.DTOs.Cita;

public class ObtenerCitaDTO
{

    public int id_agenda {get; set;}
    public int id_estudio {get; set;}
    public DateTime fecha_programada {get; set;}
    public string estado {get; set;}
    public string nombre_paciente {get; set;}
    public string nombre_estudio {get; set;}
    public string nombre_medico {get; set;}
    public string prioridad {get; set;}
    public string? notas_procedimiento {get; set;}
   
}