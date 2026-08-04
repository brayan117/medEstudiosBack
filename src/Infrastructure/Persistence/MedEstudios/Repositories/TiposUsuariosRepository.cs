using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence.MedEstudios;
using Application.Interfaces.Repositories;

namespace Infrastructure.Persistence.MedEstudios.Repositories
{
    public class TiposUsuariosRepository : ITiposUsuariosRepository
    {
        private readonly MedEstudiosDbContext _context;

        public TiposUsuariosRepository(MedEstudiosDbContext context)
        {
            _context = context;
        }

        public async Task<TiposUsuarios?> GetTipoUsuarioByIdAsync(int id)
        {
            return await _context.TiposUsuarios.FindAsync(id);
        }
    }
}