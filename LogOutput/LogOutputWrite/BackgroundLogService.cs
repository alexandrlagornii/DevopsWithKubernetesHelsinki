using System.Runtime.InteropServices;

namespace LogOutputWrite
{
  public class BackgroundLogService : BackgroundService
  {
    private readonly PeriodicTimer _timer = new PeriodicTimer(TimeSpan.FromSeconds(5));
    private readonly LogOutputWriteSingleton _logOutputSingleton;
    private readonly string _filePath = "wwwroot/logoutput.txt";

    public BackgroundLogService(LogOutputWriteSingleton logOutputSingleton)
    {
      _logOutputSingleton = logOutputSingleton;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
      do
      {
        _logOutputSingleton.LastLogEntry = $"{DateTime.Now}: {Guid.NewGuid().ToString()}";
        File.WriteAllText(_filePath, _logOutputSingleton.LastLogEntry);
        Console.WriteLine($"Written {_logOutputSingleton.LastLogEntry}");
      }
      while (await _timer.WaitForNextTickAsync(stoppingToken) &&
             !stoppingToken.IsCancellationRequested);
    }
  }
}
