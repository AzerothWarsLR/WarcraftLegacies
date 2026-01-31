using MacroTools.Commands;
using MacroTools.Utils;

namespace WarcraftLegacies.Source.Cheats;

public sealed class CheatPause : Command
{
  /// <inheritdoc />
  public override string CommandText => "pause";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(1);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Cheat;

  /// <inheritdoc />
  public override string Description => "Pauses or unpauses all selected units.";

  /// <inheritdoc />
  public override string Execute(player cheater, params string[] parameters)
  {
    var selectedUnits = GlobalGroup.EnumSelectedUnits(cheater);
    if (selectedUnits.Count == 0)
    {
      return "You're not selecting any units.";
    }

    bool toggle;
    switch (parameters[0])
    {
      case "on":
        toggle = true;
        break;
      case "off":
        toggle = false;
        break;
      default:
        return "You must specify \"on\" or \"off\" as the first parameter.";
    }

    foreach (var unit in selectedUnits)
    {
      unit.SetPausedEx(toggle);
    }

    return "Paused or unpaused selected units.";
  }
}
