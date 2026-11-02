using MacroTools.Factions;
using MacroTools.Localization;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.QuestBased;
using WarcraftLegacies.Source.Objectives.UnitBased;

namespace WarcraftLegacies.Source.Factions.FelHorde.Quests.Maghar;

/// <summary>Destroy the Alliance's Honor Hold once Stormwind has claimed it.</summary>
public sealed class QuestMagharHonorHold : QuestData
{
  private const int GoldReward = 500;

  public QuestMagharHonorHold(QuestData stormwindHonorHold, Faction stormwind, unit honorHold) : base("Honor Hold",
    "The humans have dug into Hellfire Peninsula behind the walls of Honor Hold. Their fortress stands on orc land; tear it down.",
    @"ReplaceableTextures\CommandButtons\BTNHumanBarracks.blp")
  {
    AddObjective(new ObjectiveFactionQuestComplete(stormwindHonorHold, stormwind)
    {
      ShowsInPopups = false,
      ShowsInQuestLog = false,
      Progress = QuestProgress.Undiscovered
    });
    AddObjective(new ObjectiveUnitDestroyed(honorHold));
    ResearchId = UPGRADE_R11O_QUEST_COMPLETED_HONOR_HOLD_MAGHAR;
  }

  /// <inheritdoc/>
  public override string RewardFlavour =>
    "Honor Hold burns, and the Alliance's last foothold in Hellfire Peninsula is gone.";

  /// <inheritdoc/>
  protected override string RewardDescription => Loc.Format(
    "{gold} gold, and Bonebreakers gain 150 hit points and 10 damage",
    ("{gold}", GoldReward.ToString()));

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    var owner = completingFaction.Player;
    if (owner != null)
    {
      owner.Gold += GoldReward;
    }
  }
}
