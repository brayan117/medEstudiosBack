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
}
