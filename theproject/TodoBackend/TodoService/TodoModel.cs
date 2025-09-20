using System.Text.Json.Serialization;

namespace TodoBackend.TodoService
{
  public class TodoModel
  {
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";
  }
}
