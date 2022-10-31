using WarcraftLegacies.MacroTools.QuestSystem;
using WarcraftLegacies.MacroTools.QuestSystem.UtilityStructs;

using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Goblin
{
  public sealed class QuestExplosiveEngineering : QuestData
  {
    protected override string CompletionPopup => "Gazlowee is now trainable";

    protected override string RewardDescription => "Gazlowee is trainable at the altar";

    public QuestExplosiveEngineering() : base("Explosive Engineering",
      "The Goblin chief engineer, Gazlowee, is overseeing the construction of the overseas oil platforms.",
      "ReplaceableTextures\\CommandButtons\\BTNHeroTinker.blp")
    {
      AddObjective(new ObjectiveTrain(FourCC("n0AQ"), FourCC("h04Z"), 4));
      ResearchId = FourCC("R01F");
    }
  }
}