using Domain.Entities;


namespace Application.Interfaces.Services;

public interface IAgendaService 
{
    Task<Agenda> CrearAgendaAsync(Agenda agenda);
    Task<Agenda> ObtenerAgendaPorIdAsync(int id);
    Task<IEnumerable<Agenda>> ObtenerTodasLasAgendasAsync();
    Task<Agenda> ActualizarAgendaAsync(Agenda agenda);
    Task<bool> EliminarAgendaAsync(int id);
    Task<List<Agenda>> ObtenerAgendasPorFechaProgramadaAsync(DateTime fechainicio, DateTime fechaFin);
}
