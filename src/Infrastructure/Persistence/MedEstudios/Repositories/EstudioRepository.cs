using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.MedEstudios;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Application.Interfaces.Services;

namespace Infrastructure.Persistence.MedEstudios.Repositories;

public class EstudioRepository : IEstudiosRepository
{
    private readonly MedEstudiosDbContext _context;

    public EstudioRepository(MedEstudiosDbContext context)
    {
        _context = context;
    }

    public Task<Estudio?> GetByIdAsync(int id)
    {
        return _context.Estudios.FindAsync(id).AsTask();
    }

    public async Task<List<Estudio>> GetAllAsync()
    {
        return await _context.Estudios.ToListAsync();
    }

    public Task<Estudio> AddAsync(Estudio estudio)
    {
        _context.Estudios.Add(estudio);
        return Task.FromResult(estudio);
    }

    public Task UpdateAsync(Estudio estudio)
    {
        _context.Estudios.Update(estudio);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Estudio estudio)
    {
        _context.Estudios.Remove(estudio);
        return Task.CompletedTask;
    }

    public Task SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }
}