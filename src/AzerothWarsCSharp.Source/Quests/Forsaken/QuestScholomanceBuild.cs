using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Forsaken
{
  public sealed class QuestScholomanceBuild : QuestData
  {
    //Todo: bad flavour
    protected override string CompletionPopup => "Putress is now trainable.";

    protected override string RewardDescription => "Putress is trainable at the altar";

    public QuestScholomanceBuild() : base("Secret Buildup",
      "The Scholomance is the secret staging ground for the invasion of Lordaeron, build your infrastructure and be ready for war.",
      "ReplaceableTextures\\CommandButtons\\BTNAffinityII.blp")
    {
      AddQuestItem(new ObjectiveBuild(FourCC("u011"), 2));
      AddQuestItem(new ObjectiveBuild(FourCC("h08C"), 20));
      AddQuestItem(new ObjectiveBuild(FourCC("u014"), 1));
      AddQuestItem(new ObjectiveBuild(FourCC("u01J"), 2));
      AddQuestItem(new ObjectiveUpgrade(FourCC("h08B"), FourCC("h089")));
      ResearchId = FourCC("R04Z");
    }
  }
}