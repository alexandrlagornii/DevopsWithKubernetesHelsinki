var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>
{
  string filePath = "wwwroot/logoutput.txt";
  try
  {
    string logoutput = File.ReadAllText(filePath);
    return logoutput;
  }
  catch
  {
    return string.Empty;
  }
});

app.Run();
