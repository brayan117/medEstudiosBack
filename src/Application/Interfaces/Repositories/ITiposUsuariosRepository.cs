using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface ITiposUsuariosRepository
    {
        //obtener tipo de usuario por id
        Task<TiposUsuarios?> GetTipoUsuarioByIdAsync(int id);
    }
}