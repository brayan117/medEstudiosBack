using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence.MedEstudios;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces.Services;
using Application.Interfaces.Repositories;

namespace Infrastructure.Persistence.MedEstudios.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {

        private readonly MedEstudiosDbContext _context;

        public UsuariosRepository(MedEstudiosDbContext context)
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

        public async Task DeleteUserAsync(int userId)
        {
            var usuario = await _context.Usuarios.FindAsync(userId);
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<(List<Usuario> items, int totalCount)> GetUsersPaginatedAsync(
            int page, int pageSize, string? sortBy, string? sortDirection,
            string? username, bool? estado, int? tipoUsuarioId)
        {
            var query = _context.Usuarios
                .Include(u => u.TipoUsuario)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(username))
                query = query.Where(u => u.username.ToUpper().Contains(username.ToUpper()));
            if (estado.HasValue)
                query = query.Where(u => u.estado == estado.Value);
            if (tipoUsuarioId.HasValue)
                query = query.Where(u => u.tipo_usuario_id == tipoUsuarioId.Value);

            var totalCount = await query.CountAsync();

            query = (sortBy?.ToLower(), sortDirection?.ToLower()) switch
            {
                ("username", "desc") => query.OrderByDescending(u => u.username),
                ("username", _) => query.OrderBy(u => u.username),
                ("fecha_creacion", "desc") => query.OrderByDescending(u => u.fecha_creacion),
                ("fecha_creacion", _) => query.OrderBy(u => u.fecha_creacion),
                ("estado", "desc") => query.OrderByDescending(u => u.estado),
                ("estado", _) => query.OrderBy(u => u.estado),
                (_, "desc") => query.OrderByDescending(u => u.id),
                _ => query.OrderBy(u => u.id)
            };

            var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return (items, totalCount);
        }
    }
    
}