using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Cthun;

/// <summary>
/// Rebuild Ahnqiraj to open the gate of Ahnqiraj and unlock some units.
/// </summary>
public sealed class QuestRebuildAhnqiraj : QuestData
{
  private readonly unit _gateAhnQiraj;

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestRebuildAhnqiraj"/> class.
  /// </summary>
  /// <param name="questRect">This area is where the player needs to build.</param>
  /// <param name="gateAhnQiraj">This unit will be transferred to the completeing player.</param>
  public QuestRebuildAhnqiraj(Rectangle questRect, unit gateAhnQiraj) : base("Rebuilding of Ahn'Qiraj",
    "The once great kingdom of Ahn'Qiraj was lost to the sands of time. The hive needs to awaken and be rebuilt.",
    @"ReplaceableTextures\CommandButtons\BTNCthunHatchery.blp")
  {
    _gateAhnQiraj = gateAhnQiraj;
    AddObjective(new ObjectiveBuildUniqueBuildingsInRect(questRect, "in outer Ahn'Qiraj", 3));
    AddObjective(new ObjectiveExpire(660, Title));
  }

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    if (completingFaction.Player == null)
    {
      return;
    }

    _gateAhnQiraj.IsInvulnerable = false;
    _gateAhnQiraj.SetOwner(completingFaction.Player, true);
  }

  /// <inheritdoc />
  protected override void OnFail(Faction completingFaction)
  {
    _gateAhnQiraj.IsInvulnerable = false;
    _gateAhnQiraj.SetOwner(player.NeutralAggressive, true);
  }

  /// <inheritdoc/>
  public override string RewardFlavour =>
    "The glorious kingdom of Ahn'Qiraj has now been rebuilt. The gates are open, and the world shall fear the Qiraji once more.";

  /// <inheritdoc/>
  protected override string RewardDescription => "Gain control of the gate of Ahn'Qiraj";

  /// <inheritdoc/>
  protected override void OnAdd(Faction whichFaction)
  {
    _gateAhnQiraj.IsInvulnerable = true;
  }
}
