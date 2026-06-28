using System;

namespace Domain.Entities
{
    public class TiposUsuarios
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        
        //propiedad de navegacion
        public ICollection<Usuario> Usuarios { get; set; }
    }
}