using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using MacroTools.LegendSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Cthun
{
  /// <summary>
  /// Rebuild Ahnqiraj to open the gate of Ahnqiraj and unlock some units.
  /// </summary>
  public sealed class QuestRebuildAhnqiraj : QuestData
  {

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestRebuildAhnqiraj"/> class.
    /// </summary>
    public QuestRebuildAhnqiraj(Rectangle questRect) : base(
      "Rebuilding of Ahn'qira",
      "The once great kingdom of Ahn'qiraj was lost to the sands of time. The hive needs to awaken and be rebuilt.",
      @"ReplaceableTextures\CommandButtons\BTNCthunHatchery.blp")
    {
      
      AddObjective(new ObjectiveBuildUniqueBuildingsInRect(questRect, "in outer Ahn'Qiraj", 7));
    }

    /// <inheritdoc/>
    protected override void OnComplete(Faction whichFaction)
    {
    }

    /// <inheritdoc/>
    public override string RewardFlavour =>
      "The glorious kingdom of Ahn'Qiraj has now been rebuild, the gates are open, the world shall fear the Qiraji once more.";

  }
}