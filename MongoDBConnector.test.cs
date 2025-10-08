using Xunit;
using MongoDBConnector;
using TestContainers.MongoDb;
using System.Threading.Tasks;

namespace MongoDBConnector.Tests
{
    public class MongoDBConnectorTests : IAsyncLifetime
    {
        private MongoDbContainer _mongoDbContainer;

        public async Task InitializeAsync()
        {
            _mongoDbContainer = new MongoDbBuilder().Build();
            await _mongoDbContainer.StartAsync();
        }

        public async Task DisposeAsync()
        {
            await _mongoDbContainer.DisposeAsync();
        }

        [Fact]
        public void Ping_ShouldReturnTrue_WhenConnectionIsValid()
        {
            var connector = new MongoDBConnector.MongoDBConnector(_mongoDbContainer.GetConnectionString());
            var result = connector.Ping();
            Assert.True(result);
        }

        [Fact]
        public void Ping_ShouldReturnFalse_WhenConnectionIsInvalid()
        {
            var connector = new MongoDBConnector.MongoDBConnector("mongodb://invalid:27017");
            var result = connector.Ping();
            Assert.False(result);
        }
    }
}
