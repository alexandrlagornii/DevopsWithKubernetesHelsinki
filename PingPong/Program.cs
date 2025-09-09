using PingPong;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<PostgresSettings>(options =>
{
  var configuration = options.GetRequiredService<IConfiguration>();
  return configuration.GetSection("PostgresSettings").Get<PostgresSettings>()!;
});
builder.Services.AddSingleton<RequestCounter>();

var app = builder.Build();

app.MapGet("/", async (RequestCounter requestCounter) => $"pong {await requestCounter.ShowAndIncreaseCounter()}");
app.MapGet("/pings", async (RequestCounter requestCounter) => $"Ping / Pongs: {await requestCounter.ShowCounter()}");

app.Run($"http://*:80");
