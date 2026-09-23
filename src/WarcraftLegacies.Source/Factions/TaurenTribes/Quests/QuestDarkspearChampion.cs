using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.MetaBased;
using WarcraftLegacies.Source.Objectives.QuestBased;
using WarcraftLegacies.Source.Objectives.TurnBased;

namespace WarcraftLegacies.Source.Factions.TaurenTribes.Quests;

public sealed class QuestDarkspearChampion : QuestData
{
  private const int FallbackTurn = 8;

  public QuestDarkspearChampion(QuestData orgrimmarQuest, Faction orcishHorde) : base(
    "The Darkspear Champion",
    "Rokhan, champion of the Darkspear trolls, has promised to stand with the Tauren once the Horde has a foothold in Kalimdor.",
    @"ReplaceableTextures\CommandButtons\BTNshadowhunterhd.blp")
  {
    AddObjective(new ObjectiveEitherOf(
      new ObjectiveFactionQuestComplete(orgrimmarQuest, orcishHorde),
      new ObjectiveTurn(FallbackTurn)));
    AddObjective(new ObjectiveSelfExists());
    ResearchId = UPGRADE_RT17_QUEST_COMPLETED_THE_DARKSPEAR_CHAMPION_TAUREN_TRIBES;
  }

  public override string RewardFlavour =>
    "Rokhan arrives at the Tauren camp, ready to lend his Darkspear cunning to Cairne Bloodhoof.";

  protected override string RewardDescription => "Rokhan can be trained at the Altar";
}
