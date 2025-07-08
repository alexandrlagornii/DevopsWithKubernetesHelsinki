namespace PingPong
{
  public class RequestCounter
  {
    public ulong requests = 0;

    private void IncreaseCounter() => requests++;
    public ulong ShowAndIncreaseCounter()
    {
      IncreaseCounter();
      return requests;
    }
  }
}
