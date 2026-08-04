using Domain.Entities;

namespace Application.Interfaces.Repositories;


public interface IAuditoriaRepository
{
    Task<Auditoria?> GetAuditoriaByIdAsync(int id);
    Task<List<Auditoria>> GetAllAuditoriasAsync();
    Task<Auditoria> AddAsync(Auditoria auditoria);
    Task<List<Auditoria>> GetAuditoriasByFechasAsync(DateTime fechaInicio, DateTime fechaFin);
    Task SaveChangesAsync();

    Task<(List<Auditoria> items, int totalCount)> GetAuditoriasPaginatedAsync(
        int page, int pageSize, string? sortBy, string? sortDirection,
        DateTime? fechaInicio, DateTime? fechaFin, string? accion,
        string? tablaAfectada, int? usuarioId);
}