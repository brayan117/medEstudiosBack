using Domain.Entities;

namespace Application.Interfaces
{
    public interface ITiposUsuariosRepository
    {
        //obtener tipo de usuario por id
        Task<TiposUsuarios?> GetTipoUsuarioByIdAsync(int id);
    }
}