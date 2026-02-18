using System.Runtime.CompilerServices;

namespace MacroTools.TestSupport;

public static class GameTimeManagerTest
{
  private const string Assembly = "MacroTools";
  private const string Namespace = $"{nameof(MacroTools)}.{nameof(MacroTools.GameTime)}";
  private const string Type = nameof(MacroTools.GameTime.GameTimeManager);

  [UnsafeAccessor(UnsafeAccessorKind.StaticField, Name = "_gameStarted")]
  private static extern ref bool GameStartedField([UnsafeAccessorType($"{Namespace}.{Type}, {Assembly}")] object? _ = null);

  [UnsafeAccessor(UnsafeAccessorKind.StaticField, Name = "_currentTime")]
  private static extern ref int GameTimeField([UnsafeAccessorType($"{Namespace}.{Type}, {Assembly}")] object? _ = null);

  [UnsafeAccessor(UnsafeAccessorKind.StaticField, Name = "_turnCount")]
  private static extern ref int TurnCountField([UnsafeAccessorType($"{Namespace}.{Type}, {Assembly}")] object? _ = null);

  [UnsafeAccessor(UnsafeAccessorKind.StaticField, Name = "GameStarted")]
  private static extern ref EventHandler? GameStartedHandler([UnsafeAccessorType($"{Namespace}.{Type}, {Assembly}")] object? _ = null);

  [UnsafeAccessor(UnsafeAccessorKind.StaticField, Name = "TurnEnded")]
  private static extern ref EventHandler? TurnEndedHandler([UnsafeAccessorType($"{Namespace}.{Type}, {Assembly}")] object? _ = null);

  public static bool GameStarted
  {
    get => GameStartedField();
    set => GameStartedField() = value;
  }

  public static int GameTime
  {
    get => GameTimeField();
    set => GameTimeField() = value;
  }

  public static int TurnCount
  {
    get => TurnCountField();
    set => TurnCountField() = value;
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
    GameTime = 0;
    TurnCount = 0;
    TurnEndedHandler() = null;
    GameStartedHandler() = null;
  }
}
