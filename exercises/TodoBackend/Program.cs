using TodoBackend.TodoService;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<PostgresSettings>(options =>
{
  var configuration = options.GetRequiredService<IConfiguration>();
  return configuration.GetSection("PostgresSettings").Get<PostgresSettings>()!;
});
builder.Services.AddSingleton<TodoDatabase>();
var app = builder.Build();

app.MapGet("/todos", async (TodoDatabase db) => await db.GetTodos());
app.MapPost("/todos", async (TodoModel todo, TodoDatabase db) =>
{
  if (todo.Name.Length > 140)
  {
    Console.WriteLine($"REQUEST LOG: Todo longer than 140 characters - {todo.Name}");
  }
  else
  {
    await db.AddTodo(todo);
    Console.WriteLine($"REQUEST LOG: Todo added - {todo.Name}");
  }
  return true;
});

app.Run("http://*:80");
