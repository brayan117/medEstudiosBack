using Application.Interfaces.Services;
using Domain.Entities;
using Application.Interfaces.Repositories;

namespace Application.Services;

public class EstudioService : IEstudioService
{

    private readonly IEstudiosRepository _estudioRepository;

    public EstudioService(IEstudiosRepository estudioRepository)
    {
        _estudioRepository = estudioRepository;
    }

    public async Task<Estudio> CrearEstudioAsync(Estudio estudio)
    {
        var result = await _estudioRepository.AddAsync(estudio);
        return result;
    }

    public async Task<Estudio> ObtenerEstudioPorIdAsync(int id)
    {
        return await _estudioRepository.GetByIdAsync(id)
            ?? throw new Exception($"No se encontró el estudio con id {id}");
    }

    public async Task<IEnumerable<Estudio>> ObtenerTodosLosEstudiosAsync()
    {
        return await _estudioRepository.GetAllAsync();
    }

    public async Task<Estudio> ActualizarEstudioAsync(Estudio estudio)
    {
        await _estudioRepository.UpdateAsync(estudio);
        return estudio;
    }

    public async Task<bool> EliminarEstudioAsync(int id)
    {
        var estudio = await _estudioRepository.GetByIdAsync(id);
        if (estudio == null)
        {
            return false;
        }

        await _estudioRepository.DeleteAsync(estudio);
        return true;
    }
}