using System.Text.Json.Serialization;

namespace TheProject.TodoService
{
  public class TodoModel
  {
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";
  }
}
