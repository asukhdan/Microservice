

using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace eCommerce.Infrastructure.DbContext;

public class DapperDbContext
{
    public readonly IConfiguration _configuration;
    public readonly IDbConnection _dbConnection;

    public DapperDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
        string? connectionstring = _configuration.GetConnectionString("PostgresConnection");
        _dbConnection = new NpgsqlConnection(connectionstring);

    }

    public IDbConnection DbConnection
    {
        get
        {
            return _dbConnection;
        }
    }

}
