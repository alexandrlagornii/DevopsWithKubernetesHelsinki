using System.Threading.Tasks;

namespace TheProject.RandomPicture
{
  public class RandomPictureService : BackgroundService
  {
    private readonly PeriodicTimer _time = new PeriodicTimer(TimeSpan.FromSeconds(30));
    private readonly string _randomPicturePath = "./wwwroot/RandomPicture/pic.jpg";
    private readonly string _randomPictureUri = "https://picsum.photos/1200";

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
      do
      {
        try
        {
          string directory = Path.GetDirectoryName(_randomPicturePath) ?? "";
          Directory.CreateDirectory(directory);
          if (!File.Exists(_randomPicturePath))
          {
            await DownloadPicture();
          }
          else
          {
            var lastWrite = File.GetLastWriteTime(_randomPicturePath);
            if (lastWrite.AddMinutes(10) < DateTime.Now)
            {
              await DownloadPicture();
            }
          }
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
          await Task.Delay(1000);
        }
      }
      while (await _time.WaitForNextTickAsync(stoppingToken) &&
             !stoppingToken.IsCancellationRequested);
    }

    private async Task DownloadPicture()
    {
      using (HttpClient client = new HttpClient())
      {
        byte[] imageBytes = await client.GetByteArrayAsync(_randomPictureUri);
        File.WriteAllBytes(_randomPicturePath, imageBytes);
      }
    }
  }
}
