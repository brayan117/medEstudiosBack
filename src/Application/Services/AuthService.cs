using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.DTOs.Auth;

namespace Application.Services
{
    public class AuthService
    {
        private readonly IUsuariosRepository _usuariosRepository;
        private readonly IJWTGenerator _jwtGenerator;

        public AuthService(IUsuariosRepository usuariosRepository, IJWTGenerator jwtGenerator)
        {
            _usuariosRepository = usuariosRepository;
            _jwtGenerator = jwtGenerator;
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
            return new LoginResponseDTO
            {
                token = token,
                username = usuario.username
            };
        }
    }
}