using Application.DTOs.Salus;

namespace Application.Interfaces.Repositories.Salus;

public interface IMedicoRepository
{
    Task<List<BusquedaMedicoDTO>> GetMedicoByNameAsync(string nombre);
}