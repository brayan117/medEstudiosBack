using Application.Interfaces.Repositories.Salus;
using Application.DTOs.Salus;
using Domain.Entities.Salus;
using Infrastructure.Persistence.Salus;
using Microsoft.EntityFrameworkCore;
using FirebirdSql.Data.FirebirdClient;

namespace Infrastructure.Persistence.Salus.Repositories;

public class MedicoRepository : IMedicoRepository
{
    private readonly SalusDbContext _context;
    
    public MedicoRepository(SalusDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<BusquedaMedicoDTO>> GetMedicoByNameAsync(string nombre)
    {
        var connection = _context.Database.GetDbConnection() as FbConnection;
        
        await connection.OpenAsync();
        
        using var command = connection.CreateCommand();
        command.CommandText = @"
            SELECT FIRST 10 
                ID, 
                NOMBRES 
            FROM TABLA_PROFESIONALES 
            WHERE NOMBRES CONTAINING @nombre
            ORDER BY NOMBRES";
        
        var parameter = command.CreateParameter();
        parameter.ParameterName = "@nombre";
        parameter.Value = nombre;
        command.Parameters.Add(parameter);
        
        using var reader = await command.ExecuteReaderAsync();
        
        var result = new List<BusquedaMedicoDTO>();
        
        while (await reader.ReadAsync())
        {
            result.Add(new BusquedaMedicoDTO
            {
                id = reader.GetInt32(0),
                nombres = reader.GetString(1)
            });
        }
        
        await connection.CloseAsync();
        
        return result;
    }
}