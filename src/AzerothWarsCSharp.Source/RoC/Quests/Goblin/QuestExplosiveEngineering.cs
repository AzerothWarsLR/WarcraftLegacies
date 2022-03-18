using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem;
using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Goblin
{
  public sealed class QuestExplosiveEngineering : QuestData
  {
    protected override string CompletionPopup => "Gazlowee is now trainable";

    protected override string CompletionDescription => "Gazlowee is trainable at the altar";

    public QuestExplosiveEngineering() : base("Explosive Engineering",
      "The Goblin chief engineer, Gazlowee, is overseeing the construction of the overseas oil platforms.",
      "ReplaceableTextures\\CommandButtons\\BTNHeroTinker.blp")
    {
      AddQuestItem(new QuestItemTrain(FourCC("n0AQ"), FourCC("h04Z"), 4));
      ResearchId = FourCC("R01F");
    }
  }
}