using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {

        private readonly ApplicationDbContext _context;

        public UsuariosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> GetUserByUsernameAsync(string username)
        {
            return await _context.Usuarios
            .Include(u => u.TipoUsuario)
            .FirstOrDefaultAsync(u => u.username == username);
        }

        public async Task UpdateLastLoginAsync(int userId)
        {
            var usuario = await _context.Usuarios.FindAsync(userId);
            
            if (usuario != null)
            {
                usuario.ultimo_login = DateTime.Now;
                await _context.SaveChangesAsync();
            }
        }
        
        public async Task<List<Usuario>> GetAllUsersAsync()
        {
            return await _context.Usuarios
                .Include(u => u.TipoUsuario)
                .ToListAsync();
        }
    }
    
}