using Domain.Entities;
using Application.DTOs.usuarios;

namespace Application.Interfaces
{
    public interface IUsuariosRepository
    {
        //obtener usuario por username
        Task<Usuario?> GetUserByUsernameAsync(string username);
        
        //actualizar ultimo login
        Task UpdateLastLoginAsync(int userId);

        //obtener usuario por id
        Task<Usuario?> GetUserByIdAsync(int userId);

        //actualizar estado
        Task UpdateEstadoAsync(Usuario usuario, bool nuevoEstado);

        //obtener todos los usuarios
        Task<List<Usuario>> GetAllUsersAsync();

        //agregar nuevo usuario
        Task<Usuario> AddUserAsync(Usuario usuario);

        //Eliminar usuario 
        Task DeleteUserAsync(int userId);

        //obtener usuarios paginados con filtros
        Task<(List<Usuario> items, int totalCount)> GetUsersPaginatedAsync(
            int page, int pageSize, string? sortBy, string? sortDirection,
            string? username, bool? estado, int? tipoUsuarioId);

    }
}