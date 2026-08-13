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

    public Task<Agenda?> GetByIdAsync(int id)
    {
        return _context.Agendas.FindAsync(id).AsTask();
    }

    public Task<List<Agenda>> GetAllAsync()
    {
        return _context.Agendas.ToListAsync();
    }

    public async Task<Agenda> AddAsync(Agenda agenda)
    {
        await _context.Agendas.AddAsync(agenda);
        return agenda;
    }

    public Task UpdateAsync(Agenda agenda)
    {
        _context.Agendas.Update(agenda);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Agenda agenda)
    {
        _context.Agendas.Remove(agenda);
        return Task.CompletedTask;
    }


    public async Task<List<Agenda>> GetAgendasAsyncByDate(DateTime start, DateTime end)
    {
        return await _context.Agendas
            .Where(a => a.fecha_programada >= start && a.fecha_programada <= end)
            .ToListAsync();
    }

    public async Task<List<Agenda>> ObtenerAgendasPorFechaProgramadaAsync(DateTime fechainicio, DateTime fechaFin)
    {
        return await _context.Agendas
            .Where(a => a.fecha_programada >= fechainicio && a.fecha_programada <= fechaFin)
            .ToListAsync();
    }

    public async Task<Agenda> ObtenerAgendaPorIdEstudioAsync(int idEstudio)
    {
        return await _context.Agendas
            .Where(a => a.estudio_id == idEstudio)
            .FirstOrDefaultAsync();
    }


}