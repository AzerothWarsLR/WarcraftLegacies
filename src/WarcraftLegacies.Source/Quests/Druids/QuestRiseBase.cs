using System.Collections.Generic;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Druids
{
  public sealed class QuestRiseBase : QuestData
  {
    private readonly List<unit> _rescueUnits;

    public QuestRiseBase(Rectangle rescueRect) : base("The Druid's Rise",
      "Theres a dormant ancient's grove at the base of Hyjal, take control of the area to nurture it back and awaken it!",
      @"ReplaceableTextures\CommandButtons\BTNTreeOfAges.blp")
    {
      AddObjective(new ObjectiveControlLevel(
        ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N0A0_ASCENDANT_S_RISE_10GOLD_MIN), 2));
      AddObjective(new ObjectiveExpire(1383, Title));
      AddObjective(new ObjectiveSelfExists());
      Required = true;
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);

      Required = true;
    }

    /// <inheritdoc />
    protected override string RewardFlavour =>
      "The grove has been rejuvenised and the ancients have awakened";

    /// <inheritdoc />
    protected override string RewardDescription =>
      "Control of all units in the Ascendant's Rise base";

    /// <inheritdoc />
    protected override void OnFail(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) 
        unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) 
        unit.Rescue(completingFaction.Player);
    }
  }
}