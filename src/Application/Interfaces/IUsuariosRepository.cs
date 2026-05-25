using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUsuariosRepository
    {
        //obtener usuario por username
        Task<Usuario?> GetUserByUsernameAsync(string username);
        //actualizar ultimo login
        Task UpdateLastLoginAsync(int userId);
    }
}