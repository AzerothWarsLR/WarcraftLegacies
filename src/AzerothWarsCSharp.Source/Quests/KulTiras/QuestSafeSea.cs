using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.KulTiras
{
  public sealed class QuestSafeSea : QuestData
  {
    public QuestSafeSea() : base("Safe Sea Decree",
      "The seas must be secured and the Kul'tiras navy must be returned to its former glory!", @"ReplaceableTextures\
          \CommandButtons\\BTNKulTirasDreadnought.blp")
    {
      AddQuestItem(new QuestItemTrain(FourCC("hdes"), FourCC("hshy"), 2));
      AddQuestItem(new QuestItemTrain(FourCC("h04J"), FourCC("hshy"), 1));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n01W"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n07L"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n08Q"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n09K"))));
      ResearchId = FourCC("R06T");
    }
    
    protected override string CompletionPopup =>
      "With the seas now secure, the Ember Order can be reformed and Lucille Waycrest is trainable";

    protected override string RewardDescription => "The Order of Embers is reborn and Lucille Waycrest is trainable";
  }
}