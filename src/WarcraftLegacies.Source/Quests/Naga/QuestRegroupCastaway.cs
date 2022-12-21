using MacroTools.ControlPointSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.QuestSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Naga
{
  public sealed class QuestRegroupCastaway : QuestData
  {
    public QuestRegroupCastaway() : base("The Splintered People",
      "The Naga's have been splintered throughout the world, if Illidan could reunite them, he could gain powerful allies",
      "ReplaceableTextures\\CommandButtons\\BTNNagaSeaWitch.blp")
    {
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(FourCC("n03O"))));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(FourCC("n05Y"))));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(FourCC("n04Y"))));
      //AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(FourCC("n0DJ"))));
      ResearchId = Constants.UPGRADE_R093_QUEST_COMPLETED_SPLINTERED_PEOPLE;
    }

    protected override string CompletionPopup => "All the Naga have been reunited!";

    protected override string RewardDescription => "The powerful Sea Witch are now trainable  at the Coral of Eternity";
  }
}