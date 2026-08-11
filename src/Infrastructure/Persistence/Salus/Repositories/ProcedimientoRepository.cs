using Application.Interfaces.Repositories.Salus;
using Infrastructure.Persistence.Salus;
using Domain.Entities.Salus;
using Microsoft.EntityFrameworkCore;
using FirebirdSql.Data.FirebirdClient;

namespace Infrastructure.Persistence.Salus.Repositories;

public class ProcedimientoRepository : IProcedimientoRepository
{
    private readonly SalusDbContext _context;
    
    public ProcedimientoRepository(SalusDbContext context)
    {
        _context = context;
    }

    public Task<List<Procedimiento>> GetProcedimientoByGrupoAsync(string grupo)
    {
        return _context.Procedimientos
        .Where(p => p.grupo == grupo)
        .ToListAsync();
    }

    public Task<List<Procedimiento>> GetProcedimientoByCodigoAsync(string codigo)
    {
        return _context.Procedimientos
        .Where(p => p.codigo_CUPS == codigo)
        .ToListAsync();
    }

    public async Task<List<Procedimiento>> GetProcedimientoByNombreAsync(string nombre)
    {
        var connection = _context.Database.GetDbConnection() as FbConnection;
        
        await connection.OpenAsync();
        
        using var command = connection.CreateCommand();
        command.CommandText = @"
            SELECT 
                ID_CODIGO, 
                CODICOCUPS, 
                CODIGO_SOAT, 
                NOM_PROCEDIMIENTO, 
                GRUPO, 
                ESTADO 
            FROM TABLA_CUPS 
            WHERE NOM_PROCEDIMIENTO CONTAINING @nombre";
        
        var parameter = command.CreateParameter();
        parameter.ParameterName = "@nombre";
        parameter.Value = nombre;
        command.Parameters.Add(parameter);
        
        using var reader = await command.ExecuteReaderAsync();
        
        var result = new List<Procedimiento>();
        
        while (await reader.ReadAsync())
        {
            result.Add(new Procedimiento
            {
                id_codigo = reader.GetInt32(0),
                codigo_CUPS = reader.GetString(1),
                codigo_SOAT = reader.GetString(2),
                nom_procedimiento = reader.GetString(3),
                grupo = reader.GetString(4),
                estado = reader.IsDBNull(5) ? null : reader.GetInt32(5)
            });
        }
        
        await connection.CloseAsync();
        
        return result;
    }
}