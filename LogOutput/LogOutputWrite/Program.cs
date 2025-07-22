using Microsoft.Extensions.Hosting;
using LogOutputWrite;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddSingleton<LogOutputWriteSingleton>();
builder.Services.AddHostedService<BackgroundLogService>();

var app = builder.Build();
app.Run();
