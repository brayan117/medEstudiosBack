using Domain.Entities;

namespace Application.Interfaces;

public interface IAuditoriaService
{
    Task CrearAuditoria(string accion, string tabla, int idRegistro, string descripcion,
        int? usuarioId = null, string? username = null, string? rol = null);
    Task<Auditoria?> GetAuditoriaByIdAsync(int id);
    Task<List<Auditoria>> GetAllAuditoriasAsync();
    Task<List<Auditoria>> GetAuditoriasByFechasAsync(DateTime fechaInicio, DateTime fechaFin);
}
