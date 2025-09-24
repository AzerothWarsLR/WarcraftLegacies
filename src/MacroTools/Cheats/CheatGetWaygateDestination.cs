using System.Linq;
using MacroTools.CommandSystem;
using MacroTools.Utils;

namespace MacroTools.Cheats;

public sealed class CheatGetWaygateDestination : Command
{
  /// <inheritdoc />
  public override string CommandText => "waygate";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(0);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Cheat;

  /// <inheritdoc />
  public override string Description => "Pings the Waygate destination of the first selected unit.";

  /// <inheritdoc />
  public override string Execute(player commandUser, params string[] parameters)
  {
    var selectedUnits = GlobalGroup.EnumSelectedUnits(commandUser);
    if (selectedUnits.Count == 0)
    {
      return "You're not selecting any units.";
    }

    var firstUnit = selectedUnits.First();
    var x = firstUnit.WaygateDestinationX;
    var y = firstUnit.WaygateDestinationY;

    if (!firstUnit.WaygateActive)
    {
      return $"{firstUnit.Name} is not an active Waygate.";
    }

    PingMinimap(x, y, 10);
    return $"Pinging {firstUnit.Name} Waygate destination.";
  }
}
