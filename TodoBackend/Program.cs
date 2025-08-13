using TodoBackend.TodoService;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<TodoDatabase>();
var app = builder.Build();

app.MapGet("/todos", (TodoDatabase db) => db.GetTodos());
app.MapPost("/todos", (TodoModel todo, TodoDatabase db) =>
{
  db.AddTodo(todo);
  return true;
});

app.Run("http://*:80");
