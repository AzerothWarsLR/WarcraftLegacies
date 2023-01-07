using MacroTools.ControlPointSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.Legion
{
  public sealed class QuestArgusControl : QuestData
  {
    public QuestArgusControl() : base("Argus Incursion",
      "The planet of Argus is not fully under the control of the Legion. Bring it under control!",
      "ReplaceableTextures\\CommandButtons\\BTNMastersLodge.blp")
    {
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N0BF_ANTORAN_WASTES_10GOLD_MIN)));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N0BH_EREDATH_25GOLD_MIN)));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N0BG_KROKUUN_10GOLD_MIN)));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = Constants.UPGRADE_R055_QUEST_COMPLETED_ARGUS_INCURSION;
      Required = true;
    }

    protected override string RewardDescription => "With Argus finally under the Legion's control, the invasion of Azeroth can begin!";
    
    protected override string CompletionPopup => "Enable to research Astral Walk from the Burning Citadel and build the Unholy Reliquary";
  }
}