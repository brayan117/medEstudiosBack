
using Application.Interfaces.Repositories;

namespace Infrastructure.Persistence.MedEstudios;

public class UnitOfWork : IUnitOfWork
{
    private readonly MedEstudiosDbContext _context;

    public UnitOfWork(MedEstudiosDbContext context)
    {
        _context = context;
    }

    public Task BeginTransactionAsync()
    {
        return _context.Database.BeginTransactionAsync();
    }

    public Task CommitTransactionAsync()
    {
        return _context.Database.CurrentTransaction == null
            ? Task.CompletedTask
            : _context.Database.CommitTransactionAsync();
    }

    public Task RollbackTransactionAsync()
    {
        return _context.Database.CurrentTransaction == null
            ? Task.CompletedTask
            : _context.Database.RollbackTransactionAsync();
    }
    
    public Task SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }
}
