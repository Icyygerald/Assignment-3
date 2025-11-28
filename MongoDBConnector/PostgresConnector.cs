using Npgsql;
using System.Threading.Tasks;

namespace Connectors
{
    public class PostgresConnector : IDBConnector
    {
        public async Task<bool> PingAsync(string connectionString)
        {
            try
            {
                await using var conn = new NpgsqlConnection(connectionString);
                await conn.OpenAsync();
                await using var cmd = new NpgsqlCommand("SELECT 1", conn);
                await cmd.ExecuteScalarAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
