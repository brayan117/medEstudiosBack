using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface ITecnicoRespository
{
    Task<Tecnico> AddAsync(Tecnico tecnico);
    Task<Tecnico?> GetTecnicoByIdAsync(int id);
    Task<List<Tecnico>> GetAllTecnicosAsync();
    Task<Tecnico> UpdateAsync(Tecnico tecnico);
    Task<Tecnico> DeleteAsync(Tecnico tecnico);
    Task SaveChangesAsync();
}