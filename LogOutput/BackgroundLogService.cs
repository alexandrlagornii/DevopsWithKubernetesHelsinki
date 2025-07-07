namespace LogOutput
{
  public class BackgroundLogService : BackgroundService
  {
    private readonly PeriodicTimer _timer = new PeriodicTimer(TimeSpan.FromSeconds(5));
    private readonly LogOutputSingleton _logOutputSingleton;

    public BackgroundLogService(LogOutputSingleton logOutputSingleton)
    {
      _logOutputSingleton = logOutputSingleton;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
      do
      {
        _logOutputSingleton.LastLogEntry = $"{DateTime.Now}: {Guid.NewGuid().ToString()}";
      }
      while (await _timer.WaitForNextTickAsync(stoppingToken) &&
             !stoppingToken.IsCancellationRequested);
    }
  }
}
