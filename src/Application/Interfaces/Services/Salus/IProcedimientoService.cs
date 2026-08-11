using Application.DTOs.Salus;
using Application.DTOs.Salus.Procedimiento;

namespace Application.Interfaces.Services.Salus;

public interface IProcedimientoService
{
    Task<List<ProcedimientoBusquedaDTO>> GetProcedimientoByGrupoAsync(string grupo);
    Task<List<ProcedimientoBusquedaDTO>> GetProcedimientoByCodigoAsync(string codigo);
    Task<List<ProcedimientoBusquedaDTO>> GetProcedimientosAsync(ProcedimientoBusquedaRequestDTO request);
}