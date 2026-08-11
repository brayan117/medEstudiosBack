namespace Application.DTOs.Salus;

public class ProcedimientoBusquedaDTO
{
    public int id_codigo { get; set; }
    public string codigo_CUPS { get; set; }
    public string nom_procedimiento { get; set; }
    public int? estado { get; set; }

}
