using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IEstadoEstudioRepository
{
    Task<List<EstadoEstudio>> GetAllAsync();
    Task<EstadoEstudio?> GetByIdAsync(int id);
    Task<EstadoEstudio> AddAsync(EstadoEstudio estado);
    Task UpdateAsync(EstadoEstudio estado);
    Task DeleteAsync(EstadoEstudio estado);
    Task SaveChangesAsync();
}
