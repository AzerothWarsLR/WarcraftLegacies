using MacroTools.CommandSystem;
using MacroTools.Extensions;
using MacroTools.Utils;

namespace MacroTools.Cheats
{
  /// <summary>
  /// Sets the hero level of all selected units to the specified level.
  /// </summary>
  public sealed class CheatLevel: Command
  {

    /// <inheritdoc />
    public override string CommandText => "level";

    /// <inheritdoc />
    public override ExpectedParameterCount ExpectedParameterCount => new(1);

    /// <inheritdoc />
    public override CommandType Type => CommandType.Cheat;

    /// <inheritdoc />
    public override string Description => "Sets the hero level of all selected units to the specified level.";

    /// <inheritdoc />
    public override string Execute(player cheater, params string[] parameters)
    {
      if (S2I(parameters[0]) > 0)
      {
        foreach (var unit in GlobalGroup.EnumSelectedUnits(cheater))
          unit.SetLevel(S2I(parameters[0]));
        
        return $"Setting hero level of selected units to {parameters[0]}.";
      }
      return $"Failed setting hero level of selected units to {parameters[0]} ({parameters[0]} is not a number).";
    }
  }
}