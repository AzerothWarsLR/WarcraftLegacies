using MacroTools.CommandSystem;
using MacroTools.Utils;
using static War3Api.Common;

namespace MacroTools.Cheats
{
  public sealed class CheatOwner : Command
  {
    /// <inheritdoc />
    public override string CommandText => "owner";

    /// <inheritdoc />
    public override ExpectedParameterCount ExpectedParameterCount => new(1);
    
    /// <inheritdoc />
    public override CommandType Type => CommandType.Cheat;

    /// <inheritdoc />
    public override string Description => "Sets the owner of all units to the specified player number.";
    
    /// <inheritdoc />
    public override string Execute(player cheater, params string[] parameters)
    {
      if (!int.TryParse(parameters[0], out var playerNumber))
        return "You must specify a valid player number as the first parameter.";

      var newOwner = Player(playerNumber);
      foreach (var unit in GlobalGroup.EnumSelectedUnits(cheater)) 
        SetUnitOwner(unit, newOwner, true);

      return $"Setting owner of selected units to {GetPlayerName(Player(playerNumber))}.";
    }
  }
}