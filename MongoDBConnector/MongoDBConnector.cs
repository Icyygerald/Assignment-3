using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Connectors
{
    public class MongoDBConnector : IDBConnector
    {
        public async Task<bool> PingAsync(string connectionString)
        {
            try
            {
                var client = new MongoClient(connectionString);
                var cmd = new BsonDocument("ping", 1);
                await client.GetDatabase("admin").RunCommandAsync<BsonDocument>(cmd);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
