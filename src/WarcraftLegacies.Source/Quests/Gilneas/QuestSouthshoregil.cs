using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Gilneas;

/// <summary>
/// Capture control points close to Stormglen to gain control of it.
/// </summary>
public sealed class QuestSouthshoregil : QuestData
{
  private readonly List<unit> _rescueUnits;

  public QuestSouthshoregil(Rectangle rescueRect) : base("SouthShore",
    "Southshore a great port city in Southern Lordaeron is under seige by murlocks if we clear them out they will rally to our cause.",
    @"ReplaceableTextures\CommandButtons\BTNGilneasWizardTower.blp")
  {
    AddObjective(new ObjectiveControlPoint(UNIT_N08M_SOUTHSHORE));
    AddObjective(new ObjectiveExpire(660, Title));
    AddObjective(new ObjectiveSelfExists());
    _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);

  }

  /// <inheritdoc/>
  public override string RewardFlavour => "Southshore Village has been liberated.";

  /// <inheritdoc/>
  protected override string RewardDescription => "Control of all buildings in Southshore Village";

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
      ? Player(PLAYER_NEUTRAL_AGGRESSIVE)
      : completingFaction.Player;

    rescuer.RescueGroup(_rescueUnits);
  }
}
