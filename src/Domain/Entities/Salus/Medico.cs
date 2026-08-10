namespace Domain.Entities.Salus;

public class Medico
{
    public int id {get; set;}
    public string codigo {get; set;}
    public int habilita_facturacion {get; set;}
    public string nombres {get; set;}
    public string tipo_espacialista {get; set;}
    public string cod_especialidad {get; set;}
    public string espacialidad {get; set;}
    public string reg_profesional {get; set;}
    public DateTime fecha_sistema {get; set;}
    public string documento {get; set;}
    public string estado {get; set;}
}