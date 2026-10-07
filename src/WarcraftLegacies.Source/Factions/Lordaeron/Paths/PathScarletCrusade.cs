using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Paths;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Objectives.MetaBased;

namespace WarcraftLegacies.Source.Factions.Lordaeron.Paths;

/// <summary>
/// Once the capital or Stratholme has fallen, the survivors can abandon the kingdom and rise again as the Scarlet Crusade.
/// </summary>
public sealed class PathScarletCrusade : FactionPath
{
  private readonly ScarletCrusadeTransformation _transformation;

  public PathScarletCrusade(ScarletCrusadeTransformation transformation, Capital capitalPalace, Capital stratholme)
  {
    _transformation = transformation;
    Name = "The Scarlet Crusade";
    IconName = "Divine_Reckoning_Icon";
    Description = "With the palace or Stratholme lost, the survivors turn to vengeance. All your forces are removed and you restart as the Scarlet Crusade in Tyr's Hand.";
    AddRequirement(new ObjectiveEitherOf(
      new ObjectiveCapitalLost(capitalPalace) { ShowsInQuestLog = false },
      new ObjectiveCapitalLost(stratholme) { ShowsInQuestLog = false }) { ShowsInQuestLog = false });
  }

  /// <inheritdoc />
  protected override void OnTaken(Faction faction) => _transformation.Execute(faction);
}
