using MacroTools.CommandSystem;
using MacroTools.ShoreSystem;
using MacroTools.Utils;

namespace MacroTools.Cheats;

/// <summary>
/// A cheat <see cref="Command"/> that Removes all units on the map, obliterates you, reveals the map, then spawns a large, invulnerable penguin at all registered {nameof(Shore)}s.
/// </summary>
public sealed class CheatShore : Command
{
  /// <inheritdoc />
  public override string CommandText => "shores";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(0);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Cheat;

  /// <inheritdoc />
  public override string Description =>
    $"Removes all units on the map, obliterates you, reveals the map, then spawns a large, invulnerable penguin at all registered {nameof(Shore)}s.";

  private bool _executed;

  /// <inheritdoc />
  public override string Execute(player cheater, params string[] parameters)
  {
    if (_executed)
    {
      return $"{nameof(CheatShore)} has already been executed and cannot be executed multiple times.";
    }

    _executed = true;

    foreach (var unit in GlobalGroup.EnumUnitsInRect(WCSharp.Shared.Data.Rectangle.WorldBounds))
    {
      unit.Dispose();
    }

    var newFogModifier = WCSharp.Shared.Data.Rectangle.WorldBounds.Rect.AddFogModifier(cheater, fogstate.Visible, true, true);
    newFogModifier.Start();

    foreach (var shore in ShoreManager.GetAllShores())
    {
      var newUnit = unit.Create(cheater, FourCC("npng"), shore.Position.X, shore.Position.Y, 0);
      newUnit.SetScale(7, 7, 7);
      newUnit.Name = shore.Name;
      newUnit.IsInvulnerable = true;
      newUnit.RemoveAbility(FourCC("Awan"));
    }

    return $"Created a penguin at all registered {nameof(Shore)}s.";
  }
}
