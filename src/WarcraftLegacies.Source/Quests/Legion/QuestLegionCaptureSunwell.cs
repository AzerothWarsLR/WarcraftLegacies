using MacroTools.Extensions;
using MacroTools.FactionSystem;
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
    }

    /// <inheritdoc/>
    protected override string RewardFlavour =>
      "The Sunwell has been captured by the Scourge. It now writhes with necromantic energy.";

    /// <inheritdoc/>
    protected override string RewardDescription => "Gain a research improving your Dreadlords and Nazthrezim, and grant them the ability to cast Astral Walk";

    /// <inheritdoc/>
    protected override void OnAdd(Faction whichFaction) => 
      whichFaction.ModObjectLimit(RewardResearchTypeId, Faction.UNLIMITED);

    /// <inheritdoc />
    protected override void OnComplete(Faction whichFaction)
    {
      whichFaction.SetObjectLevel(RewardResearchTypeId, 1);
      whichFaction.Player?.DisplayResearchAcquired(RewardResearchTypeId, 1);
    }
  }
}