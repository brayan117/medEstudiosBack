using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.MedEstudios;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.MedEstudios.Repositories;

public class AgendaRepository : IAgendaRepository
{

    private readonly MedEstudiosDbContext _context;

    public AgendaRepository(MedEstudiosDbContext context)
    {
        _context = context;
    }

    public async Task<Agenda> AddAsync(Agenda agenda)
    {
        await _context.Agendas.AddAsync(agenda);
        await _context.SaveChangesAsync();
        return agenda;
    }

    public async Task UpdateAsync(Agenda agenda)
    {
        _context.Agendas.Update(agenda);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Agenda agenda)
    {
        _context.Agendas.Remove(agenda);
        await _context.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<List<Agenda>> GetAgendasAsyncByDate(DateTime start, DateTime end)
    {
        return await _context.Agendas
            .Where(a => a.fecha_programada >= start && a.fecha_programada <= end)
            .ToListAsync();
    }


}