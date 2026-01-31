using System.Linq;
using MacroTools.Commands;
using MacroTools.Extensions;
using MacroTools.Utils;

namespace WarcraftLegacies.Source.Cheats;

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
      abilityString += $"{BlzGetAbilityStringField(ability, ABILITY_SF_NAME)}: {ability.Id}\n";
    }
    return $"{abilityString}";
  }
}
