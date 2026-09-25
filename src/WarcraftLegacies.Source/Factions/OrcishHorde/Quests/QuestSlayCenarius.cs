using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Objectives.QuestBased;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Factions.OrcishHorde.Quests;

public sealed class QuestSlayCenarius : QuestData
{
  public QuestSlayCenarius(QuestData previousQuest) : base(
    "The Demigod's End",
    "Cenarius, Lord of the Forest, has emerged to defend Kalimdor from the Horde's invasion. His death would break the will of the Night Elves and prove the strength of Grom Hellscream's warriors.",
    @"ReplaceableTextures\CommandButtons\BTNKeeperC.blp")
  {
    AddObjective(new ObjectiveLegendDead(AllLegends.Druids.Cenarius)
    {
      OnlyCreditKiller = true,
      PermanentOnly = false
    });
    AddObjective(new ObjectiveQuestComplete(previousQuest)
    {
      Progress = QuestProgress.Undiscovered,
      ShowsInQuestLog = false,
      ShowsInPopups = false
    });
    ResearchId = UPGRADE_R09B_QUEST_COMPLETED_THE_DEMIGOD_S_END_ORCISH_HORDE;
  }

  public override string RewardFlavour =>
    "Cenarius falls before the Horde's onslaught. Grom Hellscream stands triumphant, and word of the Grunts' resilience in that battle spreads through the clans.";

  protected override string RewardDescription =>
    "Grom Hellscream gains 5 Strength, 5 Agility, and 5 Intelligence, and Grunts permanently gain 25 hit points";

  protected override void OnComplete(Faction completingFaction)
  {
    AllLegends.Orc.GromHellscream.Unit?.AddHeroAttributes(5, 5, 5);
  }
}
