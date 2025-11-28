using System.Threading.Tasks;

namespace Connectors
{
    public interface IDBConnector
    {
        Task<bool> PingAsync(string connectionString);
    }
}
