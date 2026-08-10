using Application.DTOs.Salus;

namespace Application.Interfaces.Services.Salus;

public interface IMedicoService
{
    Task<List<BusquedaMedicoDTO>> GetMedicoByNameAsync(string nombre);
}