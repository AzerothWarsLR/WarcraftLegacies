using System.Runtime.CompilerServices;
using MacroTools.GameTime;

namespace MacroTools.TestSupport;

public static class GameTimeManagerTest
{
  private const string Assembly = "MacroTools";
  private const string Namespace = $"{nameof(MacroTools)}.{nameof(MacroTools.GameTime)}";
  private const string Type = nameof(MacroTools.GameTime.GameTimeManager);

  [UnsafeAccessor(UnsafeAccessorKind.StaticField, Name = "_gameStarted")]
  private static extern ref bool GameStartedField([UnsafeAccessorType($"{Namespace}.{Type}, {Assembly}")] object? _ = null);

  [UnsafeAccessor(UnsafeAccessorKind.StaticMethod, Name = "set_Turn")]
  private static extern void TurnSetter([UnsafeAccessorType($"{Namespace}.{Type}, {Assembly}")] object? _, int value);

  [UnsafeAccessor(UnsafeAccessorKind.StaticField, Name = "GameStarted")]
  private static extern ref EventHandler? GameStartedHandler([UnsafeAccessorType($"{Namespace}.{Type}, {Assembly}")] object? _ = null);

  [UnsafeAccessor(UnsafeAccessorKind.StaticField, Name = "TurnEnded")]
  private static extern ref EventHandler? TurnEndedHandler([UnsafeAccessorType($"{Namespace}.{Type}, {Assembly}")] object? _ = null);

  public static bool GameStarted
  {
    get => GameStartedField();
    set => GameStartedField() = value;
  }

  public static int Turn
  {
    get => GameTimeManager.Turn;
    set => TurnSetter(null, value);
  }

  public static void RaiseGameStarted()
  {
    GameStartedHandler()?.Invoke(null, EventArgs.Empty);
  }

  public static void RaiseTurnEnded()
  {
    TurnEndedHandler()?.Invoke(null, EventArgs.Empty);
  }

  public static void Reset()
  {
    GameStarted = false;
    Turn = 0;
    TurnEndedHandler() = null;
    GameStartedHandler() = null;
  }
}
