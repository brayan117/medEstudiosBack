using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IEstudiosRepository
{
    Task<IEnumerable<Estudio>> GetAllAsync();
    Task<Estudio?> GetByIdAsync(int id);
    Task<Estudio> AddAsync(Estudio estudio);
    Task UpdateAsync(Estudio estudio);
    Task DeleteAsync(Estudio estudio);
    Task SaveChangesAsync();
}