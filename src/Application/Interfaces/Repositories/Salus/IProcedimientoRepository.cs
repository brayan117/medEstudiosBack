using Domain.Entities.Salus;

namespace Application.Interfaces.Repositories.Salus;

public interface IProcedimientoRepository
{
    Task<List<Procedimiento>> GetProcedimientoByGrupoAsync(string grupo);
    Task<List<Procedimiento>> GetProcedimientoByCodigoAsync(string codigo);
    Task<List<Procedimiento>> GetProcedimientoByNombreAsync(string nombre);
}