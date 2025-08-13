namespace TodoBackend.TodoService
{
  public class TodoDatabase
  {
    private List<TodoModel> todos = new();

    public bool AddTodo(TodoModel todo)
    {
      todos.Add(todo);
      return true;
    }

    public List<TodoModel> GetTodos()
    {
      return todos;
    }
  }
}
