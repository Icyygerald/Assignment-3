using Xunit;
using Testcontainers.MongoDb;
using System.Threading.Tasks;

public class MongoDBConnectorTests : IAsyncLifetime
{
    private readonly MongoDbContainer _mongoContainer;

    public MongoDBConnectorTests()
    {
        _mongoContainer = new MongoDbBuilder().Build();
    }

    public async Task InitializeAsync() => await _mongoContainer.StartAsync();
    public async Task DisposeAsync() => await _mongoContainer.DisposeAsync();

    [Fact]
    public void Ping_ShouldReturnTrue_WhenMongoDBIsRunning()
    {
        var connector = new MongoDBConnector(_mongoContainer.GetConnectionString());
        Assert.True(connector.Ping());
    }

    [Fact]
    public void Ping_ShouldReturnFalse_WhenMongoDBConnectionFails()
    {
        var connector = new MongoDBConnector("mongodb://localhost:9999");
        Assert.False(connector.Ping());
    }
}
