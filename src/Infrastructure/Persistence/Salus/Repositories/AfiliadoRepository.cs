using Application.Interfaces.Repositories.Salus;
using Domain.Entities.Salus;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Salus.Repositories;

public class AfiliadoRepository : IAfiliadoRepository
{
    private readonly SalusDbContext _context;
    
    public AfiliadoRepository(SalusDbContext context)
    {
        _context = context;
    }
    
    public Task<Afiliado?> GetAfiliadoByDocumentoAsync(string documento)
    {
        return _context.Afiliados.FirstOrDefaultAsync(a => a.documento == documento);
    }
}
    
