namespace LogOutputReadApi.PingPongService
{
  public class PingPongClient
  {
    private readonly PingPongSettings _settings;
    private readonly HttpClient _httpClient;

    public PingPongClient(PingPongSettings settings,
                          HttpClient httpClient)
    {
      _settings = settings;
      _httpClient = httpClient;
      _httpClient.Timeout = TimeSpan.FromSeconds(20);
    }

    public async Task<string> GetPings()
    {
      string url = string.Concat(_settings.URL, "/pingpong/pings");
      using var response = await _httpClient.GetAsync(url);
      response.EnsureSuccessStatusCode();
      string responseString = await response.Content.ReadAsStringAsync();
      return responseString;
    }

    public async Task<bool> CheckHealth()
    {
      try
      {
        string url = string.Concat(_settings.URL, "/pingpong/status");
        using var response = await _httpClient.GetAsync(url);
        Console.WriteLine($"PingPong Status Code: {response.StatusCode}");
        response.EnsureSuccessStatusCode();
        return true;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        return false;
      }
    }
  }
}
