namespace Domain.Entities;

public class EstadoEstudio
{
    public int Id { get; set; }
    public string nombre { get; set; }
    public string? descripcion { get; set; }
    public int orden_flujo { get; set; }
}
