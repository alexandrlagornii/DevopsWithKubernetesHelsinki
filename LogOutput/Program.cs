while (true)
{
  string random = Guid.NewGuid().ToString();
  Console.WriteLine(random);
  Thread.Sleep(5 * 1000);
}