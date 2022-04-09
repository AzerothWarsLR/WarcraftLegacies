using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Zandalar
{
  public sealed class QuestGoldenFleet : QuestData
  {
    private static readonly int QuestResearchId = FourCC("R06W"); //This research is given when the quest is completed

    protected override string CompletionPopup => "Rastakhan is now trainable and Direhorn are available.";

    protected override string RewardDescription =>
      "Rastakhan is trainable at the altar and Direhorns are trainable";

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(QuestResearchId, 1);
    }

    public QuestGoldenFleet() : base("The Golden Fleet",
      "The King has ordered for the greatest armada in the world. The construction of the Golden Fleet has begun!",
      "ReplaceableTextures\\CommandButtons\\BTNTrollConjurer.blp")
    {
      AddQuestItem(new QuestItemTrain(FourCC("o04W"), FourCC("o049"), 5));
      ResearchId = QuestResearchId;
    }
  }
}