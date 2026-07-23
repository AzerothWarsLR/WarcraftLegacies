using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Factions.Ironforge.Quests;

/// <summary>
/// Ironforge has destroyed enemies in outland.
/// </summary>
public sealed class QuestBlackTemple : QuestData
{

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestBlackTemple"/> class.
  /// </summary>
  public QuestBlackTemple(Capital blackTemple) : base("Black Temple",
    "The Black Temple in Shadowmoon Valley is the capital for the forces of Outland. We must destroy it to stop the external threat once and for all.",
    @"ReplaceableTextures\CommandButtons\BTNInfernalFlameCannon.blp")
  {
    Knowledge = 30;

    AddObjective(new ObjectiveCapitalDead(blackTemple));
    AddObjective(new ObjectiveSelfExists());
  }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "With the Black Temple destroyed and our enemies defeated, we have secured a significant victory for Ironforge and our allies.";

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction)
  {
  }
}
