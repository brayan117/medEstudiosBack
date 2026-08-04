using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence.MedEstudios;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces.Repositories;
using Application.Interfaces;

namespace Infrastructure.Persistence.MedEstudios.Repositories;

public class TecnicoRepository : ITecnicoRespository
{

    private readonly MedEstudiosDbContext _context;

    public TecnicoRepository(MedEstudiosDbContext context)
    {
        _context = context;
    }

    public async Task<Tecnico> AddAsync(Tecnico tecnico)
    {
        _context.Tecnicos.Add(tecnico);
        return await Task.FromResult(tecnico);
    }

    public async Task<Tecnico?> GetTecnicoByIdAsync(int id)
    {
        return await _context.Tecnicos.FindAsync(id);
    }

    public async Task<List<Tecnico>> GetAllTecnicosAsync()
    {
        return await _context.Tecnicos.ToListAsync();
    }

    public async Task<Tecnico> UpdateAsync(Tecnico tecnico)
    {
        _context.Tecnicos.Update(tecnico);
        return await Task.FromResult(tecnico);
    }

    public async Task<Tecnico> DeleteAsync(Tecnico tecnico)
    {
        _context.Tecnicos.Remove(tecnico);
        return await Task.FromResult(tecnico);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}