
using Application.DTOs.usuarios;
using Application.Interfaces;
using Application.Mappers;
using Domain.Entities;
using Application.DTOs;

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

        public async Task UpdateLastLoginAsync(int userId)
        {
            await _repository.UpdateLastLoginAsync(userId);
        }

        public async Task<ResponseActualizarEstadoDTO> UpdateEstadoAsync(int userId, ActualizarEstadoDTO dto)
        {
            var usuario = await _repository.GetUserByIdAsync(userId);
            
            if (usuario == null)
            {
                return new ResponseActualizarEstadoDTO
                {
                    success = false,
                    message = "Usuario no encontrado"
                };
            }

            await _repository.UpdateEstadoAsync(usuario, dto.estado);
            
            return new ResponseActualizarEstadoDTO
            {
                success = true,
                message = "Estado actualizado correctamente"
            };
        }

        public async Task<UsuarioResponseDTO> CreateUserAsync(UsuarioRequestDTO dto)
        {

            Usuario? user = await _repository.GetUserByUsernameAsync(dto.username);
            if (user != null)
            {
                throw new Exception("El usuario ya existe");
            }
            //mapear de usuarioRequestDto a Usuario
            Usuario usuario = UsuarioMapper.ToEntity(dto);
            usuario.password_hash = BCrypt.Net.BCrypt.HashPassword(dto.password_hash);
            
            //llamar al repositorio
            var usuarioCreado = await _repository.AddUserAsync(usuario);
            
            //mapear de Usuario a UsuarioResponseDto
            return UsuarioMapper.ToResponse(usuarioCreado);
        }

        public async Task<ResponseDTO<UsuarioResponseDTO>> DeleteUserAsync(int userId)
        {
            var usuario = await _repository.GetUserByIdAsync(userId);
            
            if (usuario == null)
            {
                throw new Exception("Usuario no encontrado");
            }
            
            // Cargar la relación TipoUsuario antes de eliminar
            var usuarioConTipo = await _repository.GetUserByUsernameAsync(usuario.username);
            
            await _repository.DeleteUserAsync(userId);

            return new ResponseDTO<UsuarioResponseDTO>
            {
                success = true,
                message = "Usuario eliminado correctamente",
                data = UsuarioMapper.ToResponse(usuarioConTipo)
            };
        }
    }

}
