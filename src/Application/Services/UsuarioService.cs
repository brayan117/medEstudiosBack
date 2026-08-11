
using Application.DTOs.usuarios;
using Application.Interfaces.Repositories;
using Application.Mappers;
using Domain.Entities;
using Application.DTOs;
using Application.DTOs.Filtros;
using Application.DTOs.Paginacion;
using Application.Interfaces.Services;
using Domain.Entities.constants;


namespace Application.Services
{
    public class UsuariosService : IUsuariosService
    {
        private readonly IUsuariosRepository _repository;
        private readonly IAuditoriaService _auditoriaService;

        public UsuariosService(IUsuariosRepository repository, IAuditoriaService auditoriaService)
        {
            _repository = repository;
            _auditoriaService = auditoriaService;
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

        public async Task<PaginacionResponseDTO<UsuarioResponseDTO>> GetPaginated(UsuariosFiltroDTO filtro)
        {
            var (items, totalCount) = await _repository.GetUsersPaginatedAsync(
                filtro.page, filtro.pageSize,
                filtro.sort?.campo, filtro.sort?.direccion,
                filtro.username, filtro.estado, filtro.tipoUsuarioId);

            return new PaginacionResponseDTO<UsuarioResponseDTO>
            {
                data = items.Select(x => new UsuarioResponseDTO
                {
                    id = x.id,
                    username = x.username,
                    estado = x.estado,
                    tipoUsuario = x.TipoUsuario.nombre,
                    fechaCreacion = x.fecha_creacion,
                    ultimoLogin = x.ultimo_login
                }).ToList(),
                totalCount = totalCount,
                page = filtro.page,
                pageSize = filtro.pageSize,
                totalPages = (int)Math.Ceiling(totalCount / (double)filtro.pageSize)
            };
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

            await _auditoriaService.CrearAuditoria(
                AuditoriaAcciones.ACTUALIZAR,
                "USUARIOS",
                usuario.id,
                $"Estado actualizado a: {dto.estado}",
                usuario.id,
                usuario.username,
                usuario.TipoUsuario.nombre);
            
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

            await _auditoriaService.CrearAuditoria(
                AuditoriaAcciones.CREAR,
                "USUARIOS",
                usuarioCreado.id,
                "Usuario creado",
                usuarioCreado.id,
                usuarioCreado.username,
                usuarioCreado.TipoUsuario.nombre);
            
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
            
            await _auditoriaService.CrearAuditoria(
                AuditoriaAcciones.ELIMINAR,
                "USUARIOS",
                usuarioConTipo.id,
                "Usuario eliminado",
                usuarioConTipo.id,
                usuarioConTipo.username,
                usuarioConTipo.TipoUsuario.nombre);

            return new ResponseDTO<UsuarioResponseDTO>
            {
                success = true,
                message = "Usuario eliminado correctamente",
                data = UsuarioMapper.ToResponse(usuarioConTipo)
            };
        }
    }

}
