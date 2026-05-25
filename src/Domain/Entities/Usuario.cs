using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Usuario
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password_hash { get; set; }
        public bool estado { get; set; }
        public DateTime ultimo_login { get; set; }
        public DateTime fecha_creacion { get; set; }
    }
}