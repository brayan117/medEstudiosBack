using Application.DTOs.Paginacion;

namespace Application.DTOs.Filtros;

public class UsuariosFiltroDTO : PaginacionRequestDTO
{
    public string? username { get; set; }
    public bool? estado { get; set; }
    public int? tipoUsuarioId { get; set; }
}
