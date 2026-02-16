using System.Runtime.CompilerServices;

namespace MacroTools.Testing;

public static class GameTimeManagerTest
{
  private const string Assembly = "MacroTools";
  private const string Namespace = $"{nameof(MacroTools)}.{nameof(MacroTools.GameTime)}";
  private const string Type = nameof(MacroTools.GameTime.GameTimeManager);

  [UnsafeAccessor(UnsafeAccessorKind.StaticField, Name = "_turnCount")]
  private static extern ref int TurnCountField([UnsafeAccessorType($"{Namespace}.{Type}, {Assembly}")] object? _ = null);

  [UnsafeAccessor(UnsafeAccessorKind.StaticField, Name = "TurnEnded")]
  private static extern ref EventHandler? TurnEndedField([UnsafeAccessorType($"{Namespace}.{Type}, {Assembly}")] object? _ = null);

  public static int TurnCount
  {
    get => TurnCountField();
    set => TurnCountField() = value;
  }

  public static void RaiseTurnEnded()
  {
    TurnEndedField()?.Invoke(null, EventArgs.Empty);
  }

  public static void Reset()
  {
    TurnCount = 0;
    TurnEndedField() = null;
  }
}
