using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.GameTime;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.TurnBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Lordaeron;

/// <summary>
/// Capture Strahnbrad's control point to gain control of the village.
/// </summary>
public sealed class QuestStrahnbrad : QuestData
{
  private readonly List<unit> _rescueUnits;

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestStrahnbrad"/> class.
  /// </summary>
  /// <param name="rescueRect"></param>
  public QuestStrahnbrad(Rectangle rescueRect) : base("The Defense of Strahnbrad",
    "The Strahnbrad is under attack by some brigands, clear them out",
    @"ReplaceableTextures\CommandButtons\BTNFarm.blp")
  {
    AddObjective(
      new ObjectiveControlPoint(UNIT_N01C_STRAHNBRAD));
    AddObjective(new ObjectiveExpire(GameTimeManager.ConvertGameTimeToTurn(660), Title));
    AddObjective(new ObjectiveSelfExists());
    _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);

  }

  /// <inheritdoc/>
  protected override string RewardDescription => "Control of all buildings in Strahnbrad";

  /// <inheritdoc/>
  protected override void OnFail(Faction completingFaction)
  {
    var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
      ? player.NeutralAggressive
      : completingFaction.Player;

    rescuer.RescueGroup(_rescueUnits);
  }

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    if (completingFaction.Player != null)
    {
      completingFaction.Player.RescueGroup(_rescueUnits);
    }
  }
}
