namespace Application.Interfaces;

public interface ICurrentUser
{
    int UserId { get; }
    string Username { get; }
    string Rol { get; }
    string Ip { get; }
    string UserAgent { get; }
}