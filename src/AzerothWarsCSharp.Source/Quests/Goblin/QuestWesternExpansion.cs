using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup.Legends;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Goblin
{
  public sealed class QuestWesternExpansion : QuestData
  {
    protected override string CompletionPopup =>
      "The western shores are now clear of pesky elves, our business expansion can continue and our Zeppelins can fly safe.";

    protected override string RewardDescription => "Learn to train " + GetObjectName(FourCC("h091")) + "s";

    public QuestWesternExpansion() : base("Western Expansion",
      "Feathermoon Stronghold and Auberdine give the Elves a grip on the western shore of Kalimdor. We need to destroy them to clear a way for our business expansion west!",
      "ReplaceableTextures\\CommandButtons\\BTNNightElfShipyard.blp")
    {
      AddQuestItem(new ObjectiveLegendDead(LegendSentinels.legendFeathermoon));
      AddQuestItem(new ObjectiveLegendDead(LegendSentinels.legendAuberdine));
      ResearchId = FourCC("R07Y");
    }
  }
}