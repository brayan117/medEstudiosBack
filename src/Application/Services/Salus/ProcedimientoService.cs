using Application.DTOs.Salus;
using Application.Interfaces.Repositories.Salus;
using Application.Interfaces.Services.Salus;
using Domain.Entities.Salus;
using Application.Mappers;
using Domain.Entities.constants;
using Application.DTOs.Salus.Procedimiento;

namespace Application.Services.Salus;

public class ProcedimientoService : IProcedimientoService
{
    private readonly IProcedimientoRepository _procedimientoRepository;
    
    public ProcedimientoService(IProcedimientoRepository procedimientoRepository)
    {
        _procedimientoRepository = procedimientoRepository;
    }
    
    public Task<List<ProcedimientoBusquedaDTO>> GetProcedimientoByGrupoAsync(string grupo)
    {
        List<Procedimiento> procedimientos = _procedimientoRepository.GetProcedimientoByGrupoAsync(grupo).Result;
        return Task.FromResult(procedimientos.Select(p => ProcedimientoMapper.ToProcedimientoBusquedaDTO(p)).ToList());
    }
    
    public Task<List<ProcedimientoBusquedaDTO>> GetProcedimientoByCodigoAsync(string codigo)
    {
        List<Procedimiento> procedimientos = _procedimientoRepository.GetProcedimientoByCodigoAsync(codigo).Result;
        return Task.FromResult(procedimientos.Select(p => ProcedimientoMapper.ToProcedimientoBusquedaDTO(p)).ToList());
    }

    public Task<List<ProcedimientoBusquedaDTO>> GetProcedimientosAsync(ProcedimientoBusquedaRequestDTO request)
    {
        if (string.IsNullOrEmpty(request.tipo))
        {
            return Task.FromResult(new List<ProcedimientoBusquedaDTO>());
        }

        List<Procedimiento> procedimientos = _procedimientoRepository.GetProcedimientoByNombreAsync(request.tipo).Result;
        return Task.FromResult(procedimientos.Select(p => ProcedimientoMapper.ToProcedimientoBusquedaDTO(p)).ToList());
    }
}
