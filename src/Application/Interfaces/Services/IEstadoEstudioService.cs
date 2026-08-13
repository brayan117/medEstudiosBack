using Domain.Entities;

namespace Application.Interfaces.Services;

public interface IEstadoEstudioService
{
    Task InicializarEstadosAsync();
    Task<List<EstadoEstudio>> ObtenerTodosAsync();
}
