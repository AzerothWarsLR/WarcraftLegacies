using System.Linq;
using MacroTools.CommandSystem;
using MacroTools.Extensions;
using MacroTools.Utils;
using static War3Api.Common;
using static MacroTools.Libraries.GeneralHelpers;

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
    public override ExpectedParameterCount ExpectedParameterCount => new(0);

    /// <inheritdoc />
    public override CommandType Type => CommandType.Cheat;

    /// <inheritdoc />
    public override string Description => "Gets a list of abilities that the first selected unit has.";
  
    /// <inheritdoc />
    public override string Execute(player cheater, params string[] parameters)
    {
      var abilityString = "";
      var firstSelectedUnit = GlobalGroup.EnumSelectedUnits(cheater).First();
      foreach (var ability in firstSelectedUnit.GetUnitAbilities())
      {
        abilityString += $"{BlzGetAbilityStringField(ability,ABILITY_SF_NAME)}: {BlzGetAbilityId(ability)}\n";
      }
      return $"{abilityString}";
    }
  }
}