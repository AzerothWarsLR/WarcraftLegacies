using MacroTools.CommandSystem;
using MacroTools.Extensions;
using MacroTools.Utils;


namespace MacroTools.Cheats
{
  /// <summary>
  /// Sets the hit points of all selected units to a specified amount.
  /// </summary>
  public sealed class CheatHp: Command
  {
 
    /// <inheritdoc />
    public override string CommandText => "hp";
    
    /// <inheritdoc />
    public override bool Exact => false;

    /// <inheritdoc />
    public override int MinimumParameterCount => 1;

    /// <inheritdoc />
    public override CommandType Type => CommandType.Cheat;

    /// <inheritdoc />
    public override string Description => "Sets the hit points of all selected units to a specified amount";

    /// <inheritdoc />
    public override string Execute(player cheater, params string[] parameters)
    {
      if (S2I(parameters[0]) >= 0)
      {
        foreach (var unit in GroupUtils.GetSelectedUnits(cheater))
          SetUnitState(unit, UNIT_STATE_LIFE, S2R(parameters[0]));
        return "Setting hitpoints of selected units to " + parameters[0] + ".";
      }
      return "Failed setting hitpoints of selected units to " + parameters[0] + "(input was not a number).";
    }
  }
}