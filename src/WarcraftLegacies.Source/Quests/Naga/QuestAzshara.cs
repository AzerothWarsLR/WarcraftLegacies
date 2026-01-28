using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.QuestBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Quests.Naga;

public sealed class QuestAzsharasVein : QuestData
{
  public QuestAzsharasVein(QuestData prerequisite) : base("Azshara's Vein",
    "Eldarath and Azshara stand atop a nexus of ley lines. Lady Vashj moves to seize the area and seize the ancient magic for the Naga.",
    @"ReplaceableTextures\CommandButtons\BTNSeaWitch.blp")
  {
    AddObjective(new ObjectiveQuestComplete(prerequisite)
    {
      Progress = QuestProgress.Undiscovered,
      ShowsInQuestLog = false,
      ShowsInPopups = false
    });

    AddObjective(new ObjectiveControlPoint(UNIT_N01S_AZSHARA_COAST));
    AddObjective(new ObjectiveControlPoint(UNIT_N09R_ELDARATH));
    AddObjective(new ObjectiveLegendInRect(AllLegends.Naga.Vashj, Regions.AzsharaAmbient2, "Azshara Coast"));

    Knowledge = 10;
  }

  public override string RewardFlavour =>
    "Eldarath and Azshara stand atop a nexus of ley lines. Lady Vashj moves to seize the area and seize the ancient magic for the Naga.";
}
