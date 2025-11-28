using Xunit;
using Connectors;

public class PostgresConnectorTests
{
    [Fact]
    public async Task PingAsync_ReturnsFalse_IfInvalidConnection()
    {
        var connector = new PostgresConnector();
        var result = await connector.PingAsync("Host=bad;Username=test;Password=test");
        Assert.False(result);
    }
}
