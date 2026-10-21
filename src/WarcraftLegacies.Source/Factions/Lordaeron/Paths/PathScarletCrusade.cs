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
    Description = "The palace has fallen or Stratholme burns, and the survivors want vengeance more than a kingdom. They abandon what remains of Lordaeron and rally at Tyr's Hand as the Scarlet Crusade, sworn to purge the undead from the land.";
    AddMustStayTrueRequirement(new ObjectiveEitherOf(
      new ObjectiveCapitalLost(capitalPalace) { ShowsInQuestLog = false },
      new ObjectiveCapitalLost(stratholme) { ShowsInQuestLog = false })
    { ShowsInQuestLog = false });
  }

  /// <inheritdoc />
  protected override void OnTaken(Faction faction) => _transformation.Execute(faction);
}
