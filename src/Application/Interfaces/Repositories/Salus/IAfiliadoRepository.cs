using Domain.Entities.Salus;

namespace Application.Interfaces.Repositories.Salus;

public interface IAfiliadoRepository
{
    Task<Afiliado?> GetAfiliadoByDocumentoAsync(string documento);

}