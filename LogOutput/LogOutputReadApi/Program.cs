var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>
{
  string logoutputPath = "LogoutputShared/logoutput.txt";
  string pingpongPath = "PingpongShared/ping-pong.txt";
  try
  {
    string logoutput = File.ReadAllText(logoutputPath);
    string pingpong = File.ReadAllText(pingpongPath);
    string text = $"{logoutput}\r\n{pingpong}";
    return text;
  }
  catch (Exception ex)
  {
    return ex.Message;
  }
});

app.Run();
