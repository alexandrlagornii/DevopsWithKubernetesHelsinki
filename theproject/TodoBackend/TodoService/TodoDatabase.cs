using Npgsql;

namespace TodoBackend.TodoService
{
  public class TodoDatabase
  {
    private string _connectionString;
    public TodoDatabase(PostgresSettings settings)
    {
      _connectionString = $"Host={settings.Host};Port={settings.Port};Database={settings.Db};Username={settings.Username};Password={settings.Password};";
    }

    public async Task<bool> AddTodo(TodoModel todo)
    {
      await using var dataSource = NpgsqlDataSource.Create(_connectionString);
      await using (var cmd = dataSource.CreateCommand("INSERT INTO todos (name) VALUES ($1);"))
      {
        cmd.Parameters.AddWithValue(todo.Name);
        await cmd.ExecuteNonQueryAsync();
      }
      return true;
    }

    public async Task<List<TodoModel>> GetTodos()
    {
      var todos = new List<TodoModel>();

      await using var dataSource = NpgsqlDataSource.Create(_connectionString);
      await using (var cmd = dataSource.CreateCommand("SELECT name FROM todos"))
      await using (var reader = await cmd.ExecuteReaderAsync())
      {
        while (await reader.ReadAsync())
        {
          todos.Add(new TodoModel
          {
            Name = reader.GetString(0)
          });
        }
      }
      return todos;
    }
  }
}
