using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.Cthun
{
  /// <summary>
  /// Cthun eat the orcs and is finally happy.
  /// </summary>
  public sealed class QuestDeliciousMusculature : QuestData
  {

    /// <inheritdoc/>
    public override string RewardFlavour => "Orgrimmar has been consumed. The orcs have been defeated!";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      $"Cthun gains 2 skill points";

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestDeliciousMusculature"/> class.
    /// </summary>
    public QuestDeliciousMusculature(Capital orgrimmar) : base("Delicious Musculature",
      "The orcs have challenged C'thun long enough, it is time to eat them.",
      @"ReplaceableTextures\CommandButtons\BTNSilithid.blp")
    {
      AddObjective(new ObjectiveCapitalDead(orgrimmar));
    }

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction) {
      
    } 
  }
}