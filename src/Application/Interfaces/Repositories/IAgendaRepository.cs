using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IAgendaRepository
{
    Task<Agenda?> GetByIdAsync(int id);
    Task<List<Agenda>> GetAllAsync();
    Task<List<Agenda>> GetAgendasAsyncByDate(DateTime start, DateTime end);
    Task<Agenda> AddAsync(Agenda agenda);
    Task UpdateAsync(Agenda agenda);
    Task DeleteAsync(Agenda agenda);
    Task<List<Agenda>> ObtenerAgendasPorFechaProgramadaAsync(DateTime fechainicio, DateTime fechaFin);
    Task<Agenda> ObtenerAgendaPorIdEstudioAsync(int idEstudio); 
}