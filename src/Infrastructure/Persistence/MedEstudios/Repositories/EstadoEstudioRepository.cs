using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.MedEstudios;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.MedEstudios.Repositories;

public class EstadoEstudioRepository : IEstadoEstudioRepository
{
    private readonly MedEstudiosDbContext _context;

    public EstadoEstudioRepository(MedEstudiosDbContext context)
    {
        _context = context;
    }

    public Task<List<EstadoEstudio>> GetAllAsync()
    {
        return _context.EstadoEstudios.ToListAsync();
    }

    public Task<EstadoEstudio?> GetByIdAsync(int id)
    {
        return _context.EstadoEstudios.FindAsync(id).AsTask();
    }

    public Task<EstadoEstudio> AddAsync(EstadoEstudio estado)
    {
        _context.EstadoEstudios.Add(estado);
        return Task.FromResult(estado);
    }

    public Task UpdateAsync(EstadoEstudio estado)
    {
        _context.EstadoEstudios.Update(estado);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(EstadoEstudio estado)
    {
        _context.EstadoEstudios.Entry(estado).State = EntityState.Deleted;
        return Task.CompletedTask;
    }

    public Task SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }
}
