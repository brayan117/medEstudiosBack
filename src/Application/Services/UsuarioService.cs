
using Application.DTOs.usuarios;
using Application.Interfaces;

namespace Application.Services
{
    public class UsuariosService
    {
    private readonly IUsuariosRepository _repository;

    public UsuariosService(IUsuariosRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<UsuarioResponseDTO>> GetAll()
    {
        var usuarios = await _repository.GetAllUsersAsync();

        return usuarios.Select(x => new UsuarioResponseDTO
        {
            id = x.id,
            username = x.username,
            estado = x.estado,
            tipoUsuario = x.TipoUsuario.nombre,
            fechaCreacion = x.fecha_creacion,
            ultimoLogin = x.ultimo_login
        }).ToList();
    }
    }

}
