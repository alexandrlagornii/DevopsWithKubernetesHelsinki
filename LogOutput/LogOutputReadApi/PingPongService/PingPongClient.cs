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
    }

    public async Task<string> GetPings()
    {
      string url = string.Concat(_settings.URL, "/pings");
      using var response = await _httpClient.GetAsync(url);
      response.EnsureSuccessStatusCode();
      string responseString = await response.Content.ReadAsStringAsync();
      return responseString;
    }
  }
}
