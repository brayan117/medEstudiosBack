using Application.DTOs;
using Application.DTOs.Filtros;
using Application.DTOs.Paginacion;
using Application.DTOs.usuarios;

namespace Application.Interfaces;

public interface IUsuariosService
{
    Task<List<UsuarioResponseDTO>> GetAll();
    Task<PaginacionResponseDTO<UsuarioResponseDTO>> GetPaginated(UsuariosFiltroDTO filtro);
    Task UpdateLastLoginAsync(int userId);
    Task<ResponseActualizarEstadoDTO> UpdateEstadoAsync(int userId, ActualizarEstadoDTO dto);
    Task<UsuarioResponseDTO> CreateUserAsync(UsuarioRequestDTO dto);
    Task<ResponseDTO<UsuarioResponseDTO>> DeleteUserAsync(int userId);
}
