using System.Diagnostics.CodeAnalysis;
using TestMap.Source.Setup;

namespace TestMap.Source;

public static class Program
{
  [SuppressMessage("ReSharper", "UnusedMember.Global")]
  public static void Main()
  {
    // Delay a little since some stuff can break otherwise
    var timer = CreateTimer();
    TimerStart(timer, 0.01f, false, () =>
    {
      DestroyTimer(timer);
      Start();
    });
  }

  private static void Start()
  {
    try
    {
      GameSetup.Setup();
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex);
    }
  }
}
