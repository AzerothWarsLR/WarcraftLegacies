using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.Dalaran;

public sealed class QuestFallenGuardian : QuestData
{

  public QuestFallenGuardian(Capital karazhan) : base("The Fallen Guardian",
    "Medivh's body was corrupted by Sargeras at conception. Now that he is dead, the secrets of the Tomb of Sargeras and Karazhan combined might allow the mages of Dalaran to cleanse his spirit.",
    @"ReplaceableTextures\CommandButtons\BTNMedivh.blp")
  {
    AddObjective(new ObjectiveControlCapital(karazhan, false));
    AddObjective(new ObjectiveControlPoint(UNIT_N00J_TOMB_OF_SARGERAS, 0));
    ResearchId = UPGRADE_R04K_QUEST_COMPLETED_THE_FALLEN_GUARDIAN_DALARAN;
  }

  /// <inheritdoc/>
  public override string RewardFlavour =>
    "Medivh's spirit has been cleansed of Sargeras' influence, allowing him to return to Azeroth for a time.";

  /// <inheritdoc/>
  protected override string RewardDescription => "You can summon Medivh from the Altar of Knowledge";
}
