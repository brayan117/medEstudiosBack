using Application.DTOs.Salus;
using Domain.Entities.Salus;

namespace Application.Mappers;

public static class ProcedimientoMapper
{
    public static ProcedimientoBusquedaDTO ToProcedimientoBusquedaDTO(Procedimiento procedimiento)
    {
        return new ProcedimientoBusquedaDTO
        {
            id_codigo = procedimiento.id_codigo,
            codigo_CUPS = procedimiento.codigo_CUPS,
            nom_procedimiento = procedimiento.nom_procedimiento,
            estado = procedimiento.estado,
        };
    }
    
}