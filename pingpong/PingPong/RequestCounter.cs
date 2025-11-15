using System.Security.Cryptography;
using System.Threading.Tasks;
using Npgsql;

namespace PingPong
{
  public class RequestCounter
  {
    private string _connectionString;
    public RequestCounter(PostgresSettings settings)
    {
      _connectionString = $"Host={settings.Host};Port={settings.Port};Database={settings.Db};Username={settings.Username};Password={settings.Password};SslMode=Disable";
    }

    private async Task IncreaseCounter()
    {
      await using var dataSource = NpgsqlDataSource.Create(_connectionString);
      await using (var cmd = dataSource.CreateCommand("UPDATE pings SET number = number + 1;"))
      {
        await cmd.ExecuteNonQueryAsync();
      }
    }

    private async Task<ulong> GetCounter()
    {
      await using var dataSource = NpgsqlDataSource.Create(_connectionString);
      await using (var cmd = dataSource.CreateCommand("SELECT number FROM pings"))
      await using (var reader = await cmd.ExecuteReaderAsync())
      {
        while (await reader.ReadAsync())
        {
          return (ulong)reader.GetFieldValue<int>(0);
        }
      }

      return 0;
    }

    public async Task<ulong> ShowCounter()
    {
      return (await GetCounter()); 
    }
    
    public async Task<ulong> ShowAndIncreaseCounter()
    {
      await IncreaseCounter();
      return (await GetCounter());
    }

    public async Task<bool> HealthCheck()
    {
      try
      {
        await using var dataSource = NpgsqlDataSource.Create(_connectionString);
        await using (var cmd = dataSource.CreateCommand("Select 1;"))
        {
          await cmd.ExecuteNonQueryAsync();
          return true;
        }
      }
      catch
      {
        return false;
      }
    }
  }
}
