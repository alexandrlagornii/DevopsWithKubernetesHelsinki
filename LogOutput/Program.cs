using LogOutput;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<LogOutputSingleton>();
builder.Services.AddHostedService<BackgroundLogService>();

var app = builder.Build();

app.MapGet("/", (LogOutputSingleton logOutput) => logOutput.LastLogEntry);

app.Run("http://*:80");
