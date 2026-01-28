using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.QuestBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Quests.Naga;

public sealed class QuestAzsharasVein : QuestData
{
  public QuestAzsharasVein(QuestData prerequisite) : base("Azshara's Vein",
    "Beneath Eldarath and the coast of Azshara lies a convergence of ancient ley lines, once mapped and manipulated by the Highborne. Illidan believes the remnants of their arcane workings can still be studied to uncover knowledge thought to be long-lost.",
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
    "By examining the ley line nexus and the remnants of Highborne arcane structures, the Illidari recover forgotten principles of the arcane, expanding their understanding of Azeroth’s ancient magic.";
}
