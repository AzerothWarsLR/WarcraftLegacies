using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.Cthun
{
  /// <summary>
  /// Cthun eat the druids ally and is finally happy.
  /// </summary>
  public sealed class QuestLitheMeat : QuestData
  {

    /// <inheritdoc/>
    public override string RewardFlavour => "Auberdine or Exodar have been consumed. The enemies have been defeated!";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      $"Cthun gains 2 skill points";

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestLitheMeat"/> class.
    /// </summary>
    public QuestLitheMeat() : base("Lithe Meat",
      "Not sure how to make a quest about 2 factions pick",
      @"ReplaceableTextures\CommandButtons\BTNCthunLighthouse.blp")
    {
      //TODO Adjust objective depending on the faction
    }

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction) {
      
    } 
  }
}