using System.Text.Json;

namespace TheProject.TodoService
{
  public class TodoClient
  {
    private readonly TodoClientSettings _settings;
    private readonly HttpClient _httpClient;

    public TodoClient(TodoClientSettings settings,
                      HttpClient httpClient)
    {
      _settings = settings; 
      _httpClient = httpClient;
    }

    public async Task<bool> PostTodo(TodoModel model)
    {
      try
      {
        var jsonTodo = new StringContent(System.Text.Json.JsonSerializer.Serialize(model),
                                         System.Text.Encoding.UTF8,
                                         "application/json");
        string url = string.Concat(_settings.URL, "/todos");
        using var response = await _httpClient.PostAsync(url, jsonTodo);
        response.EnsureSuccessStatusCode();
        return true;
      }
      catch
      {
        return false;
      }
    }

    public async Task<List<TodoModel>> GetTodos()
    {
      string url = string.Concat(_settings.URL, "/todos");
      using var response = await _httpClient.GetAsync(url);
      response.EnsureSuccessStatusCode();
      var json = await response.Content.ReadAsStringAsync();
      var todoList = JsonSerializer.Deserialize<List<TodoModel>>(json);
      return todoList ?? new List<TodoModel>();
    }
  }
}
