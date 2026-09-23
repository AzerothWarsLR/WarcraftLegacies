using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Objectives.QuestBased;

namespace WarcraftLegacies.Source.Factions.TaurenTribes.Quests;

public sealed class QuestLinkWithTheMoon : QuestData
{
  public QuestLinkWithTheMoon(Capital templeOfTheMoon, QuestData previousQuest) : base(
    "Link with the Moon",
    "The Night Elves guard the sacred places of Elune jealously. Break their hold over the Temple of the Moon, and Magatha Grimtotem will lend her power to the Tauren.",
    @"ReplaceableTextures\CommandButtons\BTNMagathaGrimtotem.blp")
  {
    AddObjective(new ObjectiveCapitalDead(templeOfTheMoon));
    AddObjective(new ObjectiveSelfExists());
    AddObjective(new ObjectiveQuestComplete(previousQuest)
    {
      Progress = QuestProgress.Undiscovered,
      ShowsInQuestLog = false,
      ShowsInPopups = false
    });
    ResearchId = UPGRADE_RT18_QUEST_COMPLETED_LINK_WITH_THE_MOON_TAUREN_TRIBES;
  }

  public override string RewardFlavour =>
    "With the Temple of the Moon fallen, Magatha Grimtotem steps forward to claim her place among the Tauren elders.";

  protected override string RewardDescription => "Magatha Grimtotem can be trained at the Altar";
}
