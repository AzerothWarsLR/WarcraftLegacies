using MacroTools.CommandSystem;
using MacroTools.Extensions;
using static War3Api.Common;

namespace MacroTools.Cheats
{
  public sealed class CheatMp : Command
  {
    /// <inheritdoc />
    public override string CommandText => "mp";

    /// <inheritdoc />
    public override ExpectedParameterCount ExpectedParameterCount => new(1);
    
    /// <inheritdoc />
    public override CommandType Type => CommandType.Cheat;

    /// <inheritdoc />
    public override string Description => "Sets the mana of all selected units to the specified value.";
    
    /// <inheritdoc />
    public override string Execute(player cheater, params string[] parameters)
    {
      if (!int.TryParse(parameters[0], out var mana))
        return "You must specify a valid integer as the first parameter.";

      foreach (var unit in CreateGroup().EnumSelectedUnits(cheater).EmptyToList()) 
        unit.SetMana(mana);
      return $"Setting mana of selected units to {mana}.";
    }
  }
}