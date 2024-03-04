using System.Linq;
using MacroTools.CommandSystem;
using MacroTools.Extensions;

namespace MacroTools.Cheats
{
  /// <summary>
  /// A <see cref="Command"/> Gets a list of abilities that the first selected unit has.
  /// </summary>
  public sealed class CheatGetUnitAbilities : Command
  {
    /// <inheritdoc />
    public override string CommandText => "getAbilities";
    
    /// <inheritdoc />
    public override bool Exact => true;

    /// <inheritdoc />
    public override int MinimumParameterCount => 0;

    /// <inheritdoc />
    public override CommandType Type => CommandType.Cheat;

    /// <inheritdoc />
    public override string Description => "Gets a list of abilities that the first selected unit has.";
  
    /// <inheritdoc />
    public override string Execute(player cheater, params string[] parameters)
    {
      var abilityString = "";
      var firstSelectedUnit = CreateGroup().EnumSelectedUnits(cheater).EmptyToList().First();
      foreach (var ability in firstSelectedUnit.GetUnitAbilities())
      {
        abilityString += $"{BlzGetAbilityStringField(ability,ABILITY_SF_NAME)}: {ability.Id}\n";
      }
      return $"{abilityString}";
    }
  }
}