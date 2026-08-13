using Application.DTOs.Salus;
using Domain.Entities.Salus;

namespace Application.Interfaces.Repositories.Salus;

public interface IMedicoRepository
{
    Task<List<BusquedaMedicoDTO>> GetMedicoByNameAsync(string nombre);
    Task<Medico?> GetMedicoByIdAsync(int id);
}