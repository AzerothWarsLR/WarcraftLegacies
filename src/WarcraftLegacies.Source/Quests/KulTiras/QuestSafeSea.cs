using MacroTools.ControlPointSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.KulTiras
{
  public sealed class QuestSafeSea : QuestData
  {
    public QuestSafeSea() : base("Safe Sea Decree",
      "The seas must be secured and the Kul'tiras navy must be returned to its former glory!", @"ReplaceableTextures\
          \CommandButtons\\BTNKulTirasDreadnought.blp")
    {
      AddObjective(new ObjectiveTrain(FourCC("hdes"), FourCC("hshy"), 2));
      AddObjective(new ObjectiveTrain(FourCC("h04J"), FourCC("hshy"), 1));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n01W"))));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n07L"))));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n08Q"))));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n09K"))));
      ResearchId = FourCC("R06T");
    }

    protected override string CompletionPopup =>
      "With the seas now secure, the Ember Order can be reformed and Lucille Waycrest is trainable";

    protected override string RewardDescription => "The Order of Embers is reborn and Lucille Waycrest is trainable";
  }
}