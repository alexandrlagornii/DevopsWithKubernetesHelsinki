namespace PingPong
{
  public class RequestCounter
  {
    public ulong requests = 0;

    private readonly string _pingFilePath = "PingpongShared/ping-pong.txt";

    private void IncreaseCounter() => requests++;
    private void WriteToFile()
    {
      var text = $"Ping / Pongs: {requests}";
      File.WriteAllText(_pingFilePath, text);
    }
    public ulong ShowAndIncreaseCounter()
    {
      IncreaseCounter();
      WriteToFile();
      return requests;
    }

    public ulong ShowCounter()
    {
      return requests;
    }
  }
}
