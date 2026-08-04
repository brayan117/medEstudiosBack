using Infrastructure.Persistence.MedEstudios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace medEstudios.API.Controllers;

[ApiController]
[Route("api/test")]
public class TestController : ControllerBase
{
    private readonly MedEstudiosDbContext _context;

    public TestController(MedEstudiosDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var usuarios = await _context.Usuarios
        .Include(u => u.TipoUsuario)
        .ToListAsync();

        return Ok(usuarios);
    }
}