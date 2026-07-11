namespace Application.DTOs;

public class ResponseDTO<T>
{
    public bool success { get; set; }
    public string message { get; set; }
    public T? data { get; set; }
}
