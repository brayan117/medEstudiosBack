using Application.DTOs.Paginacion;

namespace Application.DTOs.Filtros;

public class AuditoriasFiltroDTO : PaginacionRequestDTO
{
    public DateTime? fechaInicio { get; set; }
    public DateTime? fechaFin { get; set; }
    public string? accion { get; set; }
    public string? tablaAfectada { get; set; }
    public int? usuarioId { get; set; }
}
