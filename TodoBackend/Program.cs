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
  await db.AddTodo(todo);
  return true;
});

app.Run("http://*:80");
