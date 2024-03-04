using System.Collections.Generic;
using System.Linq;
using MacroTools.CommandSystem;
using MacroTools.Extensions;


namespace MacroTools.Cheats
{
  /// <summary>
  /// A <see cref="Command"/> Removes all abilities from first selected unit.
  /// </summary>
  public sealed class CheatRemoveAllAbilities : Command
  {
    /// <inheritdoc />
    public override string CommandText => "removeAllAbilities";
    
    /// <inheritdoc />
    public override bool Exact => true;

    /// <inheritdoc />
    public override int MinimumParameterCount => 0;

    /// <inheritdoc />
    public override CommandType Type => CommandType.Cheat;

    /// <inheritdoc />
    public override string Description => "Removes all abilities from first selected unit.";
  
    /// <inheritdoc />
    public override string Execute(player cheater, params string[] parameters)
    {
      var firstSelectedUnit = CreateGroup().EnumSelectedUnits(cheater).EmptyToList().First();
      firstSelectedUnit.RemoveAllAbilities(new List<int>{1096905835,1097690998,1112498531});
      return $"All abilities removed from {firstSelectedUnit.GetName()}";
    }
  }
}