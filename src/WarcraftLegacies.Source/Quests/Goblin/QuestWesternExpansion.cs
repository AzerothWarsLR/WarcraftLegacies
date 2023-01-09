using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Goblin
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
      AddObjective(new ObjectiveCapitalDead(LegendSentinels.Feathermoon));
      AddObjective(new ObjectiveCapitalDead(LegendSentinels.Auberdine));
      ResearchId = FourCC("R07Y");
    }
  }
}