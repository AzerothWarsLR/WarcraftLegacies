using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.TurnBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Warsong.Quests;

public sealed class QuestLumberCamp : QuestData
{
  private readonly List<unit> _rescueUnits;

  public QuestLumberCamp(Rectangle rescueRect) : base("The Lumber Camp",
    "The Horde still needs to establish a strong strategic foothold into Kalimdor. Expand into Ashenvale and establish the Warsong Lumber Camp.",
    @"ReplaceableTextures\CommandButtons\BTNBarracks.blp")
  {
    AddObjective(new ObjectiveControlPoint(UNIT_MD85_CENTRAL_ASHENVALE));
    AddObjective(new ObjectiveExpire(8, Title));
    AddObjective(new ObjectiveSelfExists());

    _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
  }

  /// <inheritdoc/>
  protected override string RewardDescription => "Control of the Lumber Camp";

  private void GiveLumberCamp(player whichPlayer)
  {
    foreach (var unit in _rescueUnits)
    {
      unit.Rescue(whichPlayer);
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

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    GiveLumberCamp(completingFaction.Player);
    _rescueUnits.Clear();
  }
}
