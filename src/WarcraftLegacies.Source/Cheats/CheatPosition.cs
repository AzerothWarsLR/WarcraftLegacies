using MacroTools.Localization;
using MacroTools.Commands;
using MacroTools.Utils;

namespace WarcraftLegacies.Source.Cheats;

/// <summary>
/// A cheat that displays the position of the first selected unit.
/// </summary>
public sealed class CheatPosition : Command
{
  /// <inheritdoc />
  public override string CommandText => "position";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(0);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Cheat;

  /// <inheritdoc />
  public override string Description => "Displays the position of the first selected unit.";

  /// <inheritdoc />
  public override string Execute(player cheater, params string[] parameters)
  {
    var firstSelectedUnit = GlobalGroup.EnumSelectedUnits(cheater)[0];
    return Loc.Format("{unit} is at position {x}, {y}.", ("{unit}", firstSelectedUnit.Name), ("{x}", firstSelectedUnit.X.ToString()), ("{y}", firstSelectedUnit.Y.ToString()));
  }
}
