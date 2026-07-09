namespace Application.DTOs.usuarios;

public class UsuarioRequestDTO
{
    public string username { get; set; }
    public string password_hash { get; set; }
    public DateTime fecha_creacion { get; set; }
    public DateTime ultimo_login { get; set; }
    public int tipoUsuarioId { get; set; }
    public bool estado { get; set; }
}