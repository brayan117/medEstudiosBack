using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using Application.DTOs.Auth;
using Domain.Entities.constants;
using Domain.Entities.Constants;
using Application.Interfaces.Services;
using Application.Interfaces;

namespace Application.Services
{
    public class AuthService
    {
        private readonly IUsuariosRepository _usuariosRepository;
        private readonly IJWTGenerator _jwtGenerator;
        private readonly IAuditoriaService _auditoriaService;

        public AuthService(
            IUsuariosRepository usuariosRepository, 
            IJWTGenerator jwtGenerator, 
            IAuditoriaService auditoriaService)
        {
            _usuariosRepository = usuariosRepository;
            _jwtGenerator = jwtGenerator;
            _auditoriaService = auditoriaService;
        }


        public async Task<LoginResponseDTO> Login(LoginRequestDTO request)
        {
            var usuario = await _usuariosRepository.GetUserByUsernameAsync(request.username);
            
            if (usuario == null)
            {
                throw new Exception("Usuario no encontrado");
            }
            
            if (!BCrypt.Net.BCrypt.Verify(request.password, usuario.password_hash))
            {
                throw new Exception("Contraseña incorrecta");
            }
            
            var token = _jwtGenerator.GenerateToken(usuario);
            await _usuariosRepository.UpdateLastLoginAsync(usuario.id);

            await _auditoriaService.CrearAuditoria(
                AuditoriaAcciones.LOGIN,
                Tablas.USUARIOS,
                usuario.id,
                "Inicio de sesión exitoso",
                usuario.id,
                usuario.username,
                usuario.TipoUsuario.nombre);

            return new LoginResponseDTO
            {
                token = token,
                username = usuario.username
            };
        }
    }
}