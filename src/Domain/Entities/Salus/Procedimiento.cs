namespace Domain.Entities.Salus;

public class Procedimiento
{
    public int id_codigo {get; set;}
    public string codigo_CUPS {get; set;}
    public string codigo_SOAT {get; set;}
    public string nom_procedimiento {get; set;}
    public string grupo {get; set;}
    public int? estado {get; set;}
}
