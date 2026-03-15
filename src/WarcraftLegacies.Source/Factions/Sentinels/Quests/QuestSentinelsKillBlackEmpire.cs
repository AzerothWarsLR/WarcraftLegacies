using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Factions.Sentinels.Quests;

/// <summary>
/// Destroy Nzoth to defeat the black empire.
/// </summary>
public sealed class QuestSentinelsKillBlackEmpire : QuestData
{
  /// <summary>
  /// Initializes a new instance of the <see cref="QuestSentinelsKillBlackEmpire"/> class.
  /// </summary>
  public QuestSentinelsKillBlackEmpire() : base("Otherwordly Invaders",
    "The Black Empire has poured out near Feathermoon and begun threatening the wilds. These invaders must be repelled.",
    @"ReplaceableTextures\CommandButtons\BTNNzothIcon.blp")
  {
    AddObjective(new ObjectiveLegendDead(AllLegends.BlackEmpire.Nzoth));
    ResearchId = UPGRADE_R007_QUEST_COMPLETED_OTHERWORDLY_INVADERS_SENTINELS;

  }

  /// <inheritdoc/>
  protected override string RewardDescription => $"Allows {GetObjectName(UNIT_N034_GUILD_RANGER_SENTINELS)}s to be trained from {GetObjectName(UNIT_E00T_WATCHER_S_BASTION_SENTINELS_SIEGE)}s";

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    completingFaction.Player.SetTechResearched(ResearchId, 1);
  }

  /// <inheritdoc/>
  protected override void OnAdd(Faction whichFaction)
  {
    whichFaction.ModObjectLimit(ResearchId, Faction.Unlimited);
  }
}
