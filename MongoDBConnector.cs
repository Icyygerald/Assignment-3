using MongoDB.Driver;
using MongoDB.Bson;

public class MongoDBConnector : IDBConnector
{
    private readonly IMongoClient _client;

    public MongoDBConnector(string connectionString)
    {
        _client = new MongoClient(connectionString);
    }

    public bool Ping()
    {
        try
        {
            var database = _client.GetDatabase("admin");
            var result = database.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Result;
            return true;
        }
        catch
        {
            return false;
        }
    }
}
