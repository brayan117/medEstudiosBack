using Application.DTOs.Salus;
using Application.Interfaces.Repositories.Salus;
using Application.Interfaces.Services.Salus;

namespace Application.Services.Salus;

public class MedicoService : IMedicoService
{
    private readonly IMedicoRepository _medicoRepository;
    
    public MedicoService(IMedicoRepository medicoRepository)
    {
        _medicoRepository = medicoRepository;
    }
    
    public async Task<List<BusquedaMedicoDTO>> GetMedicoByNameAsync(string nombre)
    {
        return await _medicoRepository.GetMedicoByNameAsync(nombre);
    }
}