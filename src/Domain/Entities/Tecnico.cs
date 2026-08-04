namespace Domain.Entities;

public class Tecnico
{

    public int id {get; set;}
    public int usuario_id {get; set;}
    public string codigo_tecnico {get; set;}
    public string nombres {get; set;}
    public string apellidos {get; set;}
    public string telefono {get; set;}
    public int estado {get; set;} // este estado es para ver si esta disponible para realizar estudio
    
}