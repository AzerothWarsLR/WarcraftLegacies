using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.Cthun
{
  /// <summary>
  /// Cthun eat the Yogg and is finally happy.
  /// </summary>
  public sealed class QuestFiendThousandFaces : QuestData
  {

    /// <inheritdoc/>
    public override string RewardFlavour => "Yogg-Saron has been consumed. His genome has been added to the brood!";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      "Soldier and Super Major gain the Vampiric Attack ability";

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestFiendThousandFaces"/> class.
    /// </summary>
    public QuestFiendThousandFaces(LegendaryHero yoggsaron) : base("Fiend of a Thousand Faces",
      "Yogg-Saron is still imprisoned and weak, but holds great power. If he is released and vanquished, I can consume his power and infuse it into my the Qiraji.",
      @"ReplaceableTextures\CommandButtons\BTNCannibalize.blp")
    {
      AddObjective(new ObjectiveControlLevel(UNIT_N02S_STORM_PEAKS, 20));
      AddObjective(new ObjectiveLegendDead(yoggsaron));
      ResearchId = UPGRADE_RFTF_QUEST_COMPLETED_FIEND_OF_A_THOUSAND_FACES;
    }

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction) {
      
    } 
  }
}