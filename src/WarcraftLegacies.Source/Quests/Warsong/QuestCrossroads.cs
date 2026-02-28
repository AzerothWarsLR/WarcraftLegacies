using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.TurnBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Warsong;

public sealed class QuestCrossroads : QuestData
{
  private readonly List<unit> _rescueUnits;

  public QuestCrossroads(Rectangle rescueRect) : base("The Crossroads",
    "The Horde still needs to establish a strong strategic foothold into Kalimdor. Expand into the Barrens and claim the Crossroads.",
    @"ReplaceableTextures\CommandButtons\BTNBarracks.blp")
  {
    AddObjective(new ObjectiveControlPoint(UNIT_N01T_NORTHERN_BARRENS));
    AddObjective(new ObjectiveExpire(8, Title));
    AddObjective(new ObjectiveSelfExists());

    _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
  }

  /// <inheritdoc/>
  protected override string RewardDescription => "Control of the Crossroads";

  private void GiveCrossroads(player whichPlayer)
  {
    foreach (var unit in _rescueUnits)
    {
      unit.Rescue(whichPlayer);
    }

    unit.Create(whichPlayer, UNIT_OEYE_SENTRY_WARD_FROSTWOLF_WITCH_DOCTOR, -12844, -1975, 0);
    unit.Create(whichPlayer, UNIT_OEYE_SENTRY_WARD_FROSTWOLF_WITCH_DOCTOR, -10876, -2066, 0);
    unit.Create(whichPlayer, UNIT_OEYE_SENTRY_WARD_FROSTWOLF_WITCH_DOCTOR, -11922, -824, 0);
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
    GiveCrossroads(completingFaction.Player);
    _rescueUnits.Clear();
  }
}
