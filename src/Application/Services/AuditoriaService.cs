using Application.DTOs.Filtros;
using Application.DTOs.Paginacion;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Interfaces;
using Domain.Entities;


namespace Application.Services;

public class AuditoriaService : IAuditoriaService
{
    private readonly IAuditoriaRepository _auditoriaRepository;
    private readonly ICurrentUser _currentUserService;

    public AuditoriaService(IAuditoriaRepository auditoriaRepository, ICurrentUser currentUserService)
    {
        _auditoriaRepository = auditoriaRepository;
        _currentUserService = currentUserService;
    }

    public async Task CrearAuditoria(
        string accion,
        string tabla,
        int idRegistro,
        string descripcion,
        int? usuarioId = null,
        string? username = null,
        string? rol = null)
    {
        Auditoria auditoria = new Auditoria
        {
            usuario_id = usuarioId ?? _currentUserService.UserId,
            accion = accion,
            tabla_afectada = tabla,
            registro_id = idRegistro,
            descripcion = descripcion,
            ip = _currentUserService.Ip,
            user_agent = _currentUserService.UserAgent,
            username = username ?? _currentUserService.Username,
            rol = rol ?? _currentUserService.Rol,
            fecha = DateTime.Now
        };

        await _auditoriaRepository.AddAsync(auditoria);
        await _auditoriaRepository.SaveChangesAsync();
    }

    public async Task<Auditoria?> GetAuditoriaByIdAsync(int id)
    {
        return await _auditoriaRepository.GetAuditoriaByIdAsync(id);
    }

    public async Task<List<Auditoria>> GetAllAuditoriasAsync()
    {
        return await _auditoriaRepository.GetAllAuditoriasAsync();
    }

    public async Task<List<Auditoria>> GetAuditoriasByFechasAsync(DateTime fechaInicio, DateTime fechaFin)
    {
        return await _auditoriaRepository.GetAuditoriasByFechasAsync(fechaInicio, fechaFin);
    }

    public async Task<PaginacionResponseDTO<Auditoria>> GetPaginated(AuditoriasFiltroDTO filtro)
    {
        var (items, totalCount) = await _auditoriaRepository.GetAuditoriasPaginatedAsync(
            filtro.page, filtro.pageSize,
            filtro.sort?.campo, filtro.sort?.direccion,
            filtro.fechaInicio, filtro.fechaFin,
            filtro.accion, filtro.tablaAfectada, filtro.usuarioId);

        return new PaginacionResponseDTO<Auditoria>
        {
            data = items,
            totalCount = totalCount,
            page = filtro.page,
            pageSize = filtro.pageSize,
            totalPages = (int)Math.Ceiling(totalCount / (double)filtro.pageSize)
        };
    }
}
