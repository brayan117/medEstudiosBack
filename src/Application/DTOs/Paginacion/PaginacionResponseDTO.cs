namespace Application.DTOs.Paginacion;

public class PaginacionResponseDTO<T>
{
    public List<T> data { get; set; }
    public int totalCount { get; set; }
    public int page { get; set; }
    public int pageSize { get; set; }
    public int totalPages { get; set; }
}
