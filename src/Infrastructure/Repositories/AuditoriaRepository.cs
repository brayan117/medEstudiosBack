using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AuditoriaRepository: IAuditoriaRepository
{

    private readonly ApplicationDbContext _context;

    public AuditoriaRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Auditoria?> GetAuditoriaByIdAsync(int id)
    {
        return await _context.Auditorias.FindAsync(id);
    }

    public async Task<List<Auditoria>> GetAllAuditoriasAsync()
    {
        return await _context.Auditorias.ToListAsync();
    }

    public Task<Auditoria> AddAsync(Auditoria auditoria)
    {
        _context.Auditorias.Add(auditoria);
        return Task.FromResult(auditoria);
    }

    public async Task<List<Auditoria>> GetAuditoriasByFechasAsync(DateTime fechaInicio, DateTime fechaFin)
    {
        return await _context.Auditorias
            .Where(a => a.fecha >= fechaInicio && a.fecha <= fechaFin)
            .ToListAsync();
    }
    
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<(List<Auditoria> items, int totalCount)> GetAuditoriasPaginatedAsync(
        int page, int pageSize, string? sortBy, string? sortDirection,
        DateTime? fechaInicio, DateTime? fechaFin, string? accion,
        string? tablaAfectada, int? usuarioId)
    {
        var query = _context.Auditorias.AsQueryable();

        if (fechaInicio.HasValue)
            query = query.Where(a => a.fecha >= fechaInicio.Value);
        if (fechaFin.HasValue)
            query = query.Where(a => a.fecha <= fechaFin.Value);
        if (!string.IsNullOrWhiteSpace(accion))
            query = query.Where(a => a.accion.ToUpper().Contains(accion.ToUpper()));
        if (!string.IsNullOrWhiteSpace(tablaAfectada))
            query = query.Where(a => a.tabla_afectada.ToUpper().Contains(tablaAfectada.ToUpper()));
        if (usuarioId.HasValue)
            query = query.Where(a => a.usuario_id == usuarioId.Value);

        var totalCount = await query.CountAsync();

        query = (sortBy?.ToLower(), sortDirection?.ToLower()) switch
        {
            ("fecha", "desc") => query.OrderByDescending(a => a.fecha),
            ("fecha", _) => query.OrderBy(a => a.fecha),
            ("usuario_id", "desc") => query.OrderByDescending(a => a.usuario_id),
            ("usuario_id", _) => query.OrderBy(a => a.usuario_id),
            ("accion", "desc") => query.OrderByDescending(a => a.accion),
            ("accion", _) => query.OrderBy(a => a.accion),
            (_, "desc") => query.OrderByDescending(a => a.id),
            _ => query.OrderBy(a => a.id)
        };

        var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        return (items, totalCount);
    }
}
