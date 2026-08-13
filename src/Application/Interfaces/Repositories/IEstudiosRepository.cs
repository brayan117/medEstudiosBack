using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IEstudiosRepository
{
    Task<Estudio?> GetByIdAsync(int id);
    Task<List<Estudio>> GetAllAsync();
    Task<Estudio> AddAsync(Estudio estudio);
    Task UpdateAsync(Estudio estudio);
    Task DeleteAsync(Estudio estudio);
}