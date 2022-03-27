using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.KulTiras
{
  public sealed class QuestSafeSea : QuestData
  {
    private static readonly int QUEST_RESEARCH_ID = FourCC("R06T"); //This research is given when the quest is completed

    public QuestSafeSea() : base("Safe Sea Decree",
      "The seas must be secured and the Kul'tiras navy must be returned to its former glory!", @"ReplaceableTextures\
          \CommandButtons\\BTNKulTirasDreadnought.blp")
    {
      this.AddQuestItem(new QuestItemTrain(FourCC("hdes"),)hshy), 2));
      this.AddQuestItem(new QuestItemTrain(FourCC("h04J"),)hshy), 1));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n01W"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n07L"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n08Q"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n09K"))));
      ResearchId = QUEST_RESEARCH_ID;
    }


    protected override string CompletionPopup =>
      "With the SeaFourCC(s now secure, the Ember Order can be reformed && Lucille Waycrest is trainable";

    protected override string CompletionDescription => "The Order of Embers is reborn && Lucille Waycrest is trainable";

    protected override void OnComplete()
    {
    }
  }
}