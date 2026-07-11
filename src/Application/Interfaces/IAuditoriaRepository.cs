using Domain.Entities;

namespace Application.Interfaces;


public interface IAuditoriaRepository
{
    Task<Auditoria?> GetAuditoriaByIdAsync(int id);
    Task<List<Auditoria>> GetAllAuditoriasAsync();
    Task<Auditoria> AddAsync(Auditoria auditoria);
    Task<List<Auditoria>> GetAuditoriasByFechasAsync(DateTime fechaInicio, DateTime fechaFin);
    Task SaveChangesAsync();
}