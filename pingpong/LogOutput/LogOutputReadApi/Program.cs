using LogOutputReadApi.PingPongService;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

// Ping pong service
builder.Services.AddSingleton<PingPongSettings>(options =>
{
  var configuration = options.GetRequiredService<IConfiguration>();
  return configuration.GetSection("PingPongServiceSettings").Get<PingPongSettings>()!;
});
builder.Services.AddHttpClient<PingPongClient>();

var app = builder.Build();

app.MapGet("/", async (PingPongClient client) =>
{
  string logoutputPath = "LogoutputShared/logoutput.txt";
  string informationtxtPath = "./information.txt";
  string envVariable = "MESSAGE";
  try
  {
    string logoutput = File.ReadAllText(logoutputPath);
    string pingpong = await client.GetPings();
    string informationtxt = $"file content: {File.ReadAllText(informationtxtPath)}";
    string env = $"env variable: MESSAGE={Environment.GetEnvironmentVariable(envVariable) ?? ""}";
    string text = $"{logoutput}\r\n{pingpong}\r\n{informationtxt}\r\n{env}";
    return text;
  }
  catch (Exception ex)
  {
    return ex.Message;
  }
});

app.MapGet("/healthz", async (PingPongClient client) =>
{
  bool isHealthy = await client.CheckHealth();
  Console.WriteLine($"Is Healty {isHealthy}");
  if (isHealthy)
  {
    return Results.Ok();
  }
  else
  {
    return Results.BadRequest();
  }
});

app.Run($"http://*:80");

