using System.Data.Common;
using Music.Studio.Api.DataAccess.Interfaces;
using MySqlConnector;

namespace Music.Studio.Api.DataAccess;

public class DbContext : IDbContext
{
    private readonly IConfiguration _config;

    public DbContext(IConfiguration config)
    {
        _config = config;
    }
    
    private MySqlConnection _Connection;
    
    public DbConnection Connection
    {
        get
        {
            if (_Connection == null)
            {
                _Connection = new MySqlConnection(_config.GetConnectionString("DefaultConnection"));
            }

            return _Connection;
        }
    }
}