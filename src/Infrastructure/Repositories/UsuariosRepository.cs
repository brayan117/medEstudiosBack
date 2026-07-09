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

        public async Task<Usuario?> GetUserByIdAsync(int userId)
        {
            return await _context.Usuarios.FindAsync(userId);
        }

        public async Task UpdateEstadoAsync(Usuario usuario, bool nuevoEstado)
        {
            usuario.estado = nuevoEstado;
            await _context.SaveChangesAsync();
        }
        
        public async Task<List<Usuario>> GetAllUsersAsync()
        {
            return await _context.Usuarios
                .Include(u => u.TipoUsuario)
                .ToListAsync();
        }

        public async Task<Usuario> AddUserAsync(Usuario usuario)
        {
            // Verificar si el username ya existe
            var existingUser = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.username == usuario.username);
            
            if (existingUser != null)
            {
                throw new Exception($"El username '{usuario.username}' ya existe");
            }
            
            // Obtener el siguiente ID del generator de Firebird
            var connection = _context.Database.GetDbConnection();
            await connection.OpenAsync();
            
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT GEN_ID(GEN_USUARIOS_ID, 1) FROM RDB$DATABASE";
            var nextId = await command.ExecuteScalarAsync();
            
            await connection.CloseAsync();
            
            usuario.id = Convert.ToInt32(nextId);
            
            
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
            
            // Recargar usuario con la relación TipoUsuario
            await _context.Entry(usuario).Reference(u => u.TipoUsuario).LoadAsync();
            
            return usuario;
        }

    }
    
}