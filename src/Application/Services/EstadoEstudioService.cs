using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Domain.Entities.constants;

namespace Application.Services;

public class EstadoEstudioService : IEstadoEstudioService
{
    private readonly IEstadoEstudioRepository _repository;

    public EstadoEstudioService(IEstadoEstudioRepository repository)
    {
        _repository = repository;
    }

    public async Task InicializarEstadosAsync()
    {
        var estados = await _repository.GetAllAsync();
        
        if (estados.Any())
        {
            return; // Ya existen estados
        }

        var estadosIniciales = new List<EstadoEstudio>
        {
            new EstadoEstudio 
            { 
                Id = EstadosEstudio.Ids.AGENDADO,
                nombre = EstadosEstudio.Nombres.AGENDADO, 
                descripcion = "Estudio creado y programado para su realización",
                orden_flujo = 1
            },
            new EstadoEstudio 
            { 
                Id = EstadosEstudio.Ids.EN_PROCESO,
                nombre = EstadosEstudio.Nombres.EN_PROCESO, 
                descripcion = "Estudio actualmente en proceso de realización",
                orden_flujo = 2
            },
            new EstadoEstudio 
            { 
                Id = EstadosEstudio.Ids.REALIZADO,
                nombre = EstadosEstudio.Nombres.REALIZADO, 
                descripcion = "Estudio realizado y pendiente de informe",
                orden_flujo = 3
            },
            new EstadoEstudio 
            { 
                Id = EstadosEstudio.Ids.INFORMADO,
                nombre = EstadosEstudio.Nombres.INFORMADO, 
                descripcion = "Estudio con informe médico generado",
                orden_flujo = 4
            },
            new EstadoEstudio 
            { 
                Id = EstadosEstudio.Ids.ENTREGADO,
                nombre = EstadosEstudio.Nombres.ENTREGADO, 
                descripcion = "Resultado del estudio entregado al paciente",
                orden_flujo = 5
            },
            new EstadoEstudio 
            { 
                Id = EstadosEstudio.Ids.CANCELADO,
                nombre = EstadosEstudio.Nombres.CANCELADO, 
                descripcion = "Estudio cancelado",
                orden_flujo = 99
            }
        };

        foreach (var estado in estadosIniciales)
        {
            await _repository.AddAsync(estado);
        }

        await _repository.SaveChangesAsync();
    }

    public async Task<List<EstadoEstudio>> ObtenerTodosAsync()
    {
        return await _repository.GetAllAsync();
    }
}
