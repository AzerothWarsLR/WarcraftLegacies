using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Cthun;

/// <summary>
/// Capture 2 cps to take control of Silithus.
/// </summary>
public sealed class QuestSlitheringForward : QuestData
{
  private readonly List<unit> _outpost1Units;
  private readonly List<unit> _outpost2Units;
  private readonly List<unit> _outpost3Units;

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestSlitheringForward"/> class.
  /// </summary>
  public QuestSlitheringForward(Rectangle outpost1, Rectangle outpost2, Rectangle outpost3) : base("Slithering Forward",
    "The hive needs to grow and spread to thrive. The sands of Silithus are perfect for that purpose, but the surroundings will have to be secured first.",
    @"ReplaceableTextures/CommandButtons/BTNSilithidColossus.blp")
  {
    AddObjective(new ObjectiveControlPoint(UNIT_N047_SILITHUS));
    AddObjective(new ObjectiveControlPoint(UNIT_N00Q_SPINEBARK_GROVE));
    AddObjective(new ObjectiveExpire(660, Title));
    AddObjective(new ObjectiveSelfExists());
    _outpost1Units = outpost1.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
    _outpost2Units = outpost2.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
    _outpost3Units = outpost3.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
  }

  /// <inheritdoc />
  public override string RewardFlavour => "The land has been secured. I can now expand the hive warrens to Silithus.";

  /// <inheritdoc />
  protected override string RewardDescription => "Control of all outposts in Silithus";

  /// <inheritdoc />
  protected override void OnFail(Faction completingFaction)
  {
    var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
      ? Player(PLAYER_NEUTRAL_AGGRESSIVE)
      : completingFaction.Player;

    rescuer.RescueGroup(_outpost1Units);
    rescuer.RescueGroup(_outpost2Units);
    rescuer.RescueGroup(_outpost3Units);
  }

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction)
  {
    completingFaction.Player.RescueGroup(_outpost1Units);
    completingFaction.Player.RescueGroup(_outpost2Units);
    completingFaction.Player.RescueGroup(_outpost3Units);
  }
}
