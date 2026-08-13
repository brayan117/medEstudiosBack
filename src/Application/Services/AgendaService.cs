using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;

namespace Application.Services;

public class AgendaService : IAgendaService
{
    private readonly IAgendaRepository _repository;

    public AgendaService(IAgendaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Agenda> CrearAgendaAsync(Agenda agenda)
    {
        var result = await _repository.AddAsync(agenda);
        return result;
    }

    public async Task<Agenda> ObtenerAgendaPorIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Agenda>> ObtenerTodasLasAgendasAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Agenda> ActualizarAgendaAsync(Agenda agenda)
    {
        await _repository.UpdateAsync(agenda);
        return agenda;
    }

    public async Task<bool> EliminarAgendaAsync(int id)
    {
        var agenda = await _repository.GetByIdAsync(id);
        if (agenda == null)
        {
            return false;
        }

        await _repository.DeleteAsync(agenda);
        return true;
    }
}
