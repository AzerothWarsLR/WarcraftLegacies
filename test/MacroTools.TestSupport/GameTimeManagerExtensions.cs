using MacroTools.GameTime;

namespace MacroTools.TestSupport;

public static class GameTimeManagerExtensions
{
  extension(GameTimeManager)
  {
    public static void SetTurn(int value)
    {
      GameTimeManager.SetTurn(value);
    }

    public static void Reset()
    {
      GameTimeManager.Reset();
    }
  }
}
