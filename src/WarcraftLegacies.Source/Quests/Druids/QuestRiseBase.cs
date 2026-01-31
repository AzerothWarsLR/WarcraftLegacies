using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.TimeBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Druids;

public sealed class QuestRiseBase : QuestData
{
  private readonly List<unit> _rescueUnits;

  public QuestRiseBase(Rectangle rescueRect) : base("The Druid's Rise",
    "Theres a dormant ancient's grove at the base of Hyjal, take control of the area to nurture it back and awaken it!",
    @"ReplaceableTextures\CommandButtons\BTNTreeOfAges.blp")
  {
    AddObjective(new ObjectiveControlLevel(UNIT_N0A0_ASCENDANT_S_RISE, 2));
    AddObjective(new ObjectiveExpire(480, Title));
    AddObjective(new ObjectiveSelfExists());

    _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
  }

  /// <inheritdoc />
  protected override string RewardDescription =>
    "Control of all units in the Ascendant's Rise base";

  /// <inheritdoc />
  protected override void OnFail(Faction completingFaction)
  {
    var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
      ? player.NeutralAggressive
      : completingFaction.Player;

    rescuer.RescueGroup(_rescueUnits);
  }

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction)
  {
    completingFaction.Player.RescueGroup(_rescueUnits);
  }
}
