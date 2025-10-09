using Xunit;
using Testcontainers.PostgreSql;
using System.Threading.Tasks;

public class PostgresConnectorTests : IAsyncLifetime
{
    private readonly PostgreSqlContainer _postgresContainer;

    public PostgresConnectorTests()
    {
        _postgresContainer = new PostgreSqlBuilder()
            .WithDatabase("testdb")
            .WithUsername("postgres")
            .WithPassword("password")
            .Build();
    }

    public async Task InitializeAsync() => await _postgresContainer.StartAsync();
    public async Task DisposeAsync() => await _postgresContainer.DisposeAsync();

    [Fact]
    public void Ping_ShouldReturnTrue_WhenPostgresIsRunning()
    {
        var connector = new PostgresConnector(_postgresContainer.GetConnectionString());
        Assert.True(connector.Ping());
    }

    [Fact]
    public void Ping_ShouldReturnFalse_WhenPostgresIsUnavailable()
    {
        var connector = new PostgresConnector("Host=localhost;Port=9999;Username=wrong;Password=wrong;Database=wrong");
        Assert.False(connector.Ping());
    }
}
