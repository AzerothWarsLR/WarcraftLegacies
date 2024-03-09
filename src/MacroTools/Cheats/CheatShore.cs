using MacroTools.CommandSystem;
using MacroTools.Extensions;
using MacroTools.ShoreSystem;
using MacroTools.Utils;


namespace MacroTools.Cheats
{
  /// <summary>
  /// A cheat <see cref="Command"/> that Removes all units on the map, obliterates you, reveals the map, then spawns a large, invulnerable penguin at all registered {nameof(Shore)}s.
  /// </summary>
  public sealed class CheatShore : Command
  {
    /// <inheritdoc />
    public override string CommandText => "shores";
    
    /// <inheritdoc />
    public override bool Exact => true;

    /// <inheritdoc />
    public override int MinimumParameterCount => 0;

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
        return $"{nameof(CheatShore)} has already been executed and cannot be executed multiple times.";

      _executed = true;

      foreach (var unit in GroupUtils.GetUnitsInRect(WCSharp.Shared.Data.Rectangle.WorldBounds))
        unit.Dispose();

      var newFogModifier = CreateFogModifierRect(cheater, FOG_OF_WAR_VISIBLE,
        WCSharp.Shared.Data.Rectangle.WorldBounds.Rect, true, true);
      FogModifierStart(newFogModifier);
      
      foreach (var shore in ShoreManager.GetAllShores())
      {
        var shoreIndicator = CreateUnit(cheater, FourCC("npng"), shore.Position.X, shore.Position.Y, 0);
        SetUnitScale(shoreIndicator, 7, 7, 7);
        shoreIndicator.Name = shore.Name;
        shoreIndicator.IsInvulnerable = true;
        shoreIndicator.RemoveAbility(FourCC("Awan"));
      }

      return $"Created a penguin at all registered {nameof(Shore)}s.";
    }
  }
}