using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Gilneas;

/// <summary>
/// Capture control Hinterlands,Jinth'alor and Arathi Highlands to Subjegate Dalaran.
/// </summary>
public sealed class QuestDalarangilneas : QuestData
{
  private readonly List<unit> _rescueUnits;

  public QuestDalarangilneas(Rectangle rescueRect1) : base("Dalaran", "To force the mages of Dalaran to submit to our might we must Secure the outlying regions of the Arathi Highlands, " +
    "The Hinterlands and the Troll city of Jintha'alor", @"ReplaceableTextures\CommandButtons\BTNArcaneCastle.blp")
  {
    _rescueUnits = rescueRect1.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
    AddObjective(new ObjectiveUpgrade(UNIT_H02C_CASTLE_GILNEAS_T3, UNIT_H01R_TOWN_HALL_GILNEAS_T1));
    AddObjective(new ObjectiveControlPoint(UNIT_N01A_HINTERLANDS));
    AddObjective(new ObjectiveControlPoint(UNIT_N0EB_JINTHA_ALOR));
    AddObjective(new ObjectiveControlPoint(UNIT_N01Z_ARATHI_HIGHLANDS));
    AddObjective(new ObjectiveExpire(660, "Dalaran"));
    AddObjective(new ObjectiveSelfExists());
  }

  /// <inheritdoc/>
  public override string RewardFlavour => "The mages of Dalaran has decided to submit to our might after noticing our resurgent control of Southern-Lordaeron to help defeat the Scourge.";

  /// <inheritdoc/>
  protected override string RewardDescription => "Control of all buildings in Dalaran.";

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    foreach (var unit in _rescueUnits)
    {
      unit.Rescue(completingFaction.Player);
    }
  }

  /// <inheritdoc/>
  protected override void OnFail(Faction completingFaction)
  {
    var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
      ? player.NeutralAggressive
      : completingFaction.Player;

    rescuer.RescueGroup(_rescueUnits);
  }
}
