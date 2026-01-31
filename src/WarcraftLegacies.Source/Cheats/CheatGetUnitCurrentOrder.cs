using System.Linq;
using MacroTools.Commands;
using MacroTools.Utils;

namespace WarcraftLegacies.Source.Cheats;

/// <summary>
/// A <see cref="Command"/> Gets the current order of the first selected unit.
/// </summary>
public sealed class CheatGetUnitCurrentOrder : Command
{
  /// <inheritdoc />
  public override string CommandText => "getOrder";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(0);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Cheat;

  /// <inheritdoc />
  public override string Description => "Gets the current order of the first selected unit.";

  /// <inheritdoc />
  public override string Execute(player cheater, params string[] parameters)
  {
    var orderString = "";
    var firstSelectedUnit = GlobalGroup.EnumSelectedUnits(cheater).First();

    orderString += $"{OrderId2String(firstSelectedUnit.CurrentOrder)}: {firstSelectedUnit.CurrentOrder}\n";

    return $"{orderString}";
  }
}
