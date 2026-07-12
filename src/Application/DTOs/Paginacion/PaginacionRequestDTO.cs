namespace Application.DTOs.Paginacion;

public class PaginacionRequestDTO
{
    public int page { get; set; } = 1;
    public int pageSize { get; set; } = 10;
    public SortDTO? sort { get; set; }
}
