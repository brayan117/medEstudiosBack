using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.Auth
{
    public class LoginResponseDTO
    {
        public string token { get; set; }
        public string username { get; set; }
    }
}