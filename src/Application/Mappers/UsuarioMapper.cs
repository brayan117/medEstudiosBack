namespace Application.Mappers;
using Domain.Entities;
using Application.DTOs.usuarios;

public static class UsuarioMapper
{
    public static Usuario ToEntity(UsuarioRequestDTO dto)
    {
        return new Usuario
        {
            username = dto.username,
            password_hash = dto.password_hash,
            fecha_creacion = dto.fecha_creacion,
            ultimo_login = dto.ultimo_login,
            tipo_usuario_id = dto.tipoUsuarioId,
            estado = dto.estado
        };
    }
    
    public static UsuarioResponseDTO ToResponse(Usuario usuario)
    {
        return new UsuarioResponseDTO
        {
            id = usuario.id,
            username = usuario.username,
            estado = usuario.estado,
            tipoUsuario = usuario.TipoUsuario.nombre,
            fechaCreacion = usuario.fecha_creacion,
            ultimoLogin = usuario.ultimo_login
        };
    }
}
