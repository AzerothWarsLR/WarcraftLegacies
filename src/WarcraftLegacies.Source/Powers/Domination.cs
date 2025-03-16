using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.Utils;

namespace WarcraftLegacies.Source.Powers
{
  /// <summary>
  /// Allows the holder to train and control mindless Undead as long as one of their Lich King units holds the
  /// Helm of Domination.
  /// </summary>
  public sealed class Domination : Power
  {
    /// <summary>Active when the <see cref="Power"/> is active, inactive otherwise.</summary>
    public required int ResearchId { get; init; }

    /// <summary>Players can only control these when they have this Power.</summary>
    public required List<int> MindlessUndeadUnitTypes { get; init; }

    public Domination()
    {
      Name = "Domination";
      Description = "You can train and control Ghouls, Abominations, Frost Wyrms, and Crypt Fiends.";
    }

    /// <inheritdoc />
    public override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(ResearchId, Faction.UNLIMITED);
      whichFaction.SetObjectLevel(ResearchId, 1);
    }

    /// <inheritdoc />
    public override void OnRemove(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(ResearchId, -Faction.UNLIMITED);
      whichFaction.SetObjectLevel(ResearchId, 0);
    }

    /// <inheritdoc />
    public override void OnRemove(player whichPlayer)
    {
      KillUndead(whichPlayer);
    }

    private void KillUndead(player whichPlayer)
    {
      var playerUnits = GlobalGroup
        .EnumUnitsOfPlayer(whichPlayer);

      foreach (var unit in playerUnits)
        if (MindlessUndeadUnitTypes.Contains(unit.GetTypeId()))
          unit.Kill();
    }
  }
}