using LogOutputReadApi.PingPongService;

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
  try
  {
    string logoutput = File.ReadAllText(logoutputPath);
    string pingpong = await client.GetPings();
    string text = $"{logoutput}\r\n{pingpong}";
    return text;
  }
  catch (Exception ex)
  {
    return ex.Message;
  }
});

app.Run();
