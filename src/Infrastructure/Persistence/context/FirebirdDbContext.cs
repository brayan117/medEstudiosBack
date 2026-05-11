using Microsoft.Extensions.Configuration;
using FirebirdSql.Data.FirebirdClient;

namespace Infrastructure.Persistence.context;

public class FirebirdDbContext
{
    private readonly string _conexionString;
    
    public FirebirdDbContext(IConfiguration configuration)
    {
        _conexionString = configuration.GetConnectionString("FirebirdConnection")
        ?? throw new InvalidOperationException("Connection string 'FirebirdConnection' not found.");
    }
    
    public FbConnection CreateConnection()
    {
        return new FbConnection(_conexionString);
    }
}

/*

aqui se realiz la conexion a firebir por medio del appsettings.json
usando Configuration para realizar los ajustes
no debe modificarse
 
 */