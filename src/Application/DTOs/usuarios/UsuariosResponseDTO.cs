namespace Application.DTOs.usuarios
{
    public class UsuarioResponseDTO
    {
        public int id { get; set; }
        public string username { get; set; }
        public int tipoUsuarioId { get; set; }
        public string tipoUsuario { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime ultimoLogin { get; set; }
        public bool estado { get; set; }
    }
}