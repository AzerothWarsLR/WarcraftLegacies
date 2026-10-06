// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

namespace WarcraftLegacies24p;

public static class Program
{
  public static void Main()
  {
    var startTimer = timer.Create();
    startTimer.Start(0.01f, false, () =>
    {
      startTimer.Dispose();
      Start();
    });
  }

  private static void Start()
  {
    player.LocalPlayer.DisplayTextTo("Hello World!");
  }
}
