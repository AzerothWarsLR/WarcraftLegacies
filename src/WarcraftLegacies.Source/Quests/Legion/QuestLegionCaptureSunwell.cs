using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.Legion
{
  public sealed class QuestLegionCaptureSunwell : QuestData
  {
    private const int RewardResearchTypeId = Constants.UPGRADE_R054_QUEST_COMPLETED_FALL_OF_SILVERMOON;
    
    public QuestLegionCaptureSunwell(Capital sunwell) : base("Fall of Silvermoon",
      "The Sunwell is the source of the High Elves' immortality and magical prowess. Under control of the Scourge, it would be the source of immense necromantic power.",
      @"ReplaceableTextures\CommandButtons\BTNOrbOfCorruption.blp")
    {
      AddObjective(new ObjectiveControlCapital(sunwell, false));
      ResearchId = Constants.UPGRADE_R054_QUEST_COMPLETED_FALL_OF_SILVERMOON;
    }

    /// <inheritdoc/>
    protected override string RewardFlavour =>
      "The Sunwell has been captured by the Legion. It now writhes with demonic energy.";

    /// <inheritdoc/>
    protected override string RewardDescription => "Improves Dreadlords and Nathrezim by increasing their attack damage by 20, movement speed by 20, hit points by 200, and granting them the ability to cast Astral Walk";


  }
}