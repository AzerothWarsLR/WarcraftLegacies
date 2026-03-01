using MacroTools.GameTime;

namespace MacroTools.TestSupport;

public static class GameTimeManagerTest
{
  public static int Turn
  {
    get => GameTimeManager.Turn;
    set => GameTimeManager.SetTurn(value);
  }

  public static void Reset()
  {
    Turn = 0;
  }
}
