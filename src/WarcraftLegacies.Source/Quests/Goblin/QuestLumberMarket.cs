using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.Goblin
{
  /// <inheritdoc />
  public sealed class QuestLumberMarket : QuestData
  {
    
    /// <inheritdoc/>
    public override string RewardFlavour => "The World Tree is ours, our shredders have their work cut out for them!";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      $"Shredders gain the Cleaving Attack ability and 500 hit points";

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestLumberMarket"/> class.
    /// </summary>
    public QuestLumberMarket(Capital nordrassil) : base("The Biggest Tree",
      "The World Tree would provide a good challenge for our best shredders.",
      @"ReplaceableTextures\CommandButtons\BTNJunkGolem.blp")
    {
      AddObjective(new ObjectiveControlCapital(nordrassil, false));
      ResearchId = UPGRADE_R07Z_QUEST_COMPLETED_THE_BIGGEST_TREE;
    }
    
  }
}