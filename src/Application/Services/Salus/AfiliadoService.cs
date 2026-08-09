using Application.Interfaces.Repositories.Salus;
using Domain.Entities.Salus;
using Application.Interfaces.Services.Salus;

namespace Application.Services.Salus;

public class AfiliadoService: IAfiliadoService
{

    private readonly IAfiliadoRepository _afiliadoRepository;
    
    public AfiliadoService(IAfiliadoRepository afiliadoRepository)
    {
        _afiliadoRepository = afiliadoRepository;
    }
    
    public async Task<Afiliado?> GetAfiliadoByDocumentoAsync(string documento)
    {
        return await _afiliadoRepository.GetAfiliadoByDocumentoAsync(documento);
    }
    
}