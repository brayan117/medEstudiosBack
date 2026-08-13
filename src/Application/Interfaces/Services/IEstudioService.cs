
using Domain.Entities;

namespace Application.Interfaces.Services;

public interface IEstudioService
{
    Task<Estudio> CrearEstudioAsync(Estudio estudio);
    Task<Estudio> ObtenerEstudioPorIdAsync(int id);
    Task<IEnumerable<Estudio>> ObtenerTodosLosEstudiosAsync();
    Task<Estudio> ActualizarEstudioAsync(Estudio estudio);
    Task<bool> EliminarEstudioAsync(int id);
    Task<List<Estudio>> ObtenerEstudiosPorFechaProgramadaAsync(DateTime fecha_inicio, DateTime fecha_fin);
}