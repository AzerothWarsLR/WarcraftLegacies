using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.Cthun
{
  /// <summary>
  /// Cthun kills the Druids and is finally happy.
  /// </summary>
  public sealed class QuestWarOfTheShiftingSand : QuestData
  {

    /// <inheritdoc/>
    public override string RewardFlavour => "Nordrassil has been consumed. The War of the Shifting Sand is finally over!";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      $"Gain the Forced Evolution power and Cthun gains skill points";

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestWarOfTheShiftingSand"/> class.
    /// </summary>
    public QuestWarOfTheShiftingSand(Capital nordrassil) : base("War of the Shifting Sand",
      "The World Tree, Nordrassil, is the Night Elves' source of immortality. A permanent afront to the loss of the Qiraji millenia ago. It needs to burn.",
      @"ReplaceableTextures\CommandButtons\BTNCthunIcon.blp")
    {
      AddObjective(new ObjectiveControlCapital(nordrassil, false));
    }

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction) {
      
    } 
  }
}