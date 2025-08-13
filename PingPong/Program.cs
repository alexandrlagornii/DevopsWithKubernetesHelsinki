using PingPong;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<RequestCounter>();

var app = builder.Build();

app.MapGet("/pingpong", (RequestCounter requestCounter) => $"pong {requestCounter.ShowAndIncreaseCounter()}");
app.MapGet("/pings", (RequestCounter requestCounter) => $"Ping / Pongs: {requestCounter.ShowCounter()}");

app.Run($"http://*:80");
