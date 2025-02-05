using System.Linq;
using MacroTools.CommandSystem;
using MacroTools.Utils;
using static War3Api.Common;

namespace MacroTools.Cheats
{
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

      orderString += $"{OrderId2String(GetUnitCurrentOrder(firstSelectedUnit))}: {GetUnitCurrentOrder(firstSelectedUnit)}\n";

      return $"{orderString}";
    }
  }
}