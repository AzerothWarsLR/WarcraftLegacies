using System.Runtime.CompilerServices;
using MacroTools.GameTime;

namespace MacroTools.TestSupport;

public static class GameTimeManagerTest
{
  private const string Assembly = "MacroTools";
  private const string Namespace = $"{nameof(MacroTools)}.{nameof(MacroTools.GameTime)}";
  private const string Type = nameof(MacroTools.GameTime.GameTimeManager);

  [UnsafeAccessor(UnsafeAccessorKind.StaticMethod, Name = "set_Turn")]
  private static extern void TurnSetter([UnsafeAccessorType($"{Namespace}.{Type}, {Assembly}")] object? _, int value);

  public static int Turn
  {
    get => GameTimeManager.Turn;
    set => TurnSetter(null, value);
  }

  public static void Reset()
  {
    Turn = 0;
  }
}
