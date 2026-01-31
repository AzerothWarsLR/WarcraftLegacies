using System.Collections.Generic;
using System.Linq;
using MacroTools.Artifacts;
using MacroTools.Commands;
using MacroTools.Extensions;
using MacroTools.Utils;

namespace WarcraftLegacies.Source.Cheats;

public sealed class AssembleZinrokh : Command
{
  private readonly List<Artifact> _zinrokhFragments;

  public AssembleZinrokh(List<Artifact> zinrokhFragments)
  {
    _zinrokhFragments = zinrokhFragments;
  }

  /// <inheritdoc />
  public override string CommandText => "assemblezinrokh";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(0);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Cheat;

  /// <inheritdoc />
  public override string Description => "Moves all Zin'rokh fragments to the currently selected unit.";

  /// <inheritdoc />
  public override string Execute(player commandUser, params string[] parameters)
  {
    var selectedUnit = GlobalGroup.EnumSelectedUnits(commandUser).First();
    foreach (var artifact in _zinrokhFragments)
    {
      selectedUnit.AddItemSafe(artifact.Item);
    }

    return "Moved all Zin'rokh fragments to the currently selected unit.";
  }
}
