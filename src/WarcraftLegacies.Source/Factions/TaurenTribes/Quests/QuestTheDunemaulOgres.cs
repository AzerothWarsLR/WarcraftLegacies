using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.QuestBased;

namespace WarcraftLegacies.Source.Factions.TaurenTribes.Quests;

public sealed class QuestTheDunemaulOgres : QuestData
{
  public QuestTheDunemaulOgres(QuestData previousQuest) : base(
    "The Dunemaul Ogres",
    "The Dunemaul ogres roam the sands of Tanaris. Bring them to heel and the ogres of the Tauren Tribes will learn from their savage strength.",
    @"ReplaceableTextures\CommandButtons\BTNOgreLord.blp")
  {
    AddObjective(new ObjectiveControlPoint(UNIT_N020_TANARIS));
    AddObjective(new ObjectiveSelfExists());
    AddObjective(new ObjectiveQuestComplete(previousQuest)
    {
      Progress = QuestProgress.Undiscovered,
      ShowsInQuestLog = false,
      ShowsInPopups = false
    });
    ResearchId = UPGRADE_RT19_QUEST_COMPLETED_THE_DUNEMAUL_OGRES_TAUREN_TRIBES;
  }

  public override string RewardFlavour =>
    "The Dunemaul are humbled, and the ogres serving the Tauren grow stronger for the lessons learned in the desert.";

  protected override string RewardDescription =>
    "Ogre Crushers, Ogre Stone Throwers, Ogre Magi and Ogre Lords permanently gain 100 hit points and 5 attack damage";
}
