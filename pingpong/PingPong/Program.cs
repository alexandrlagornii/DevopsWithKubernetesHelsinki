using Microsoft.AspNetCore.Http.HttpResults;
using PingPong;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<PostgresSettings>(options =>
{
  var configuration = options.GetRequiredService<IConfiguration>();
  return configuration.GetSection("PostgresSettings").Get<PostgresSettings>()!;
});
builder.Services.AddSingleton<RequestCounter>();

var app = builder.Build();

app.MapGet("/pingpong/", async (RequestCounter requestCounter) => $"pong {await requestCounter.ShowAndIncreaseCounter()}");
app.MapGet("/pingpong/pings", async (RequestCounter requestCounter) => $"Ping / Pongs: {await requestCounter.ShowCounter()}");
app.MapGet("/pingpong/healthz", async (RequestCounter requestCounter) =>
{
  bool isHealthy = await requestCounter.HealthCheck();
  if (isHealthy)
  {
    return Results.Ok();
  }
  else
  {
    return Results.BadRequest();
  }
});
app.MapGet("/pingpong/status", () =>
{
  return Results.Ok();
});

app.Run($"http://*:80");
