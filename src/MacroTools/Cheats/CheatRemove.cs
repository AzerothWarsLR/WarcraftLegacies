using MacroTools.CommandSystem;
using MacroTools.Extensions;
using static War3Api.Common;

namespace MacroTools.Cheats
{
  public sealed class CheatRemove : Command
  {
    /// <inheritdoc />
    public override string CommandText => "remove";

    /// <inheritdoc />
    public override ExpectedParameterCount ExpectedParameterCount => new(0);
    
    /// <inheritdoc />
    public override CommandType Type => CommandType.Cheat;

    /// <inheritdoc />
    public override string Description => "Removes all selected units.";
    
    /// <inheritdoc />
    public override string Execute(player cheater, params string[] parameters)
    {
      foreach (var unit in CreateGroup().EnumSelectedUnits(cheater).EmptyToList()) 
        RemoveUnit(unit);
      return "Permanently removing selected units.";
    }
  }
}