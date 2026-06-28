using System;

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
        public int tipo_usuario_id { get; set; }

        //propiedad de navegacion
        public TiposUsuarios TipoUsuario { get; set; }
    }
}