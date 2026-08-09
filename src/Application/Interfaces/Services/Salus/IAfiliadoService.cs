using Domain.Entities.Salus;

namespace Application.Interfaces.Services.Salus;

public interface IAfiliadoService
{
     Task<Afiliado?> GetAfiliadoByDocumentoAsync(string documento);
}