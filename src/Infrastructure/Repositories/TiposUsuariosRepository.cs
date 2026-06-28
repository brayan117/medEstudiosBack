using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Repositories
{
    public class TiposUsuariosRepository : ITiposUsuariosRepository
    {
        private readonly ApplicationDbContext _context;

        public TiposUsuariosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TiposUsuarios?> GetTipoUsuarioByIdAsync(int id)
        {
            return await _context.TiposUsuarios.FindAsync(id);
        }
    }
}