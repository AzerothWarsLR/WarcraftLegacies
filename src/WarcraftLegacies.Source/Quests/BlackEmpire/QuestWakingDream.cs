using MacroTools;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.BlackEmpire
{
  public sealed class QuestWakingDream : QuestData
  {

    public QuestWakingDream(LegendaryHero channelingHero, PreplacedUnitSystem preplacedUnitSystem) : base("Waking Dream",
      "Countless ages ago, Warlord Zon'ozz was one of my strongest generals. Unfortunately, he is currently trapped in the past. To summon him, I need to capture the Caverns of Time and call him to serve me in the present once again.",
      @"ReplaceableTextures\CommandButtons\BTNDarkPortal.blp")
    {
      AddObjective(new ObjectiveKillUnit(preplacedUnitSystem.GetUnit(UNIT_O070_OCCULUS_CREEP_CAVERNS)));
      ResearchId = UPGRADE_RBWD_QUEST_COMPLETED_WAKING_DREAM;

    }

    /// <inheritdoc/>
    public override string RewardFlavour =>
      "Zon'ozz has joined my ranks once more.";

    /// <inheritdoc/>
    protected override string RewardDescription => $"Learn to train Warlord Zon'ozz from the {GetObjectName(UNIT_N0AV_ALTAR_OF_MADNESS_YOGG_ALTAR)}";

   
  }
}