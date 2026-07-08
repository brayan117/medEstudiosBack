using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUsuariosRepository
    {
        //obtener usuario por username
        Task<Usuario?> GetUserByUsernameAsync(string username);
        
        //actualizar ultimo login
        Task UpdateLastLoginAsync(int userId);

        //obtener todos los usuarios
        Task<List<Usuario>> GetAllUsersAsync();
    }
}