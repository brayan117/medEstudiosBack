using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {

        private readonly ApplicationDbContext _context;

        public UsuariosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Usuario?> GetUserByUsernameAsync(string username)
        {
            return Task.FromResult(_context.Usuarios.FirstOrDefault(u => u.username == username));
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
    }
}