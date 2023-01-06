using System.Collections.Generic;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Lordaeron
{
  /// <summary>
  /// Wait long enough, get Tyr Hand.
  /// </summary>
  public sealed class QuestTyrHand : QuestData
  {
    private readonly List<unit> _rescueUnits;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestTyrHand"/> class.
    /// </summary>
    /// <param name="rescueRect">Units in this area will start invulnerable and be rescued when the quest is complete.</param>
    public QuestTyrHand(Rectangle rescueRect) : base("The Fortified City",
      "The city of Tyr's Hand is considered impregnable, but they will be reluctant to join the war",
      "ReplaceableTextures\\CommandButtons\\BTNHumanBarracks.blp")
    {
      AddObjective(new ObjectiveControlLevel(
        ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N03P_CORIN_S_CROSSING_10GOLD_MIN), 20));
      AddObjective(new ObjectiveControlLevel(
        ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N044_HEARTHGLEN_10GOLD_MIN), 20));
      AddObjective(new ObjectiveExpire(1335));
      AddObjective(new ObjectiveSelfExists());
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
      Required = true;
    }

    /// <inheritdoc />
    protected override string CompletionPopup => "The city-fortress of Tyr's Hand has decided to join us!";

    /// <inheritdoc />
    protected override string RewardDescription => "Control of all units in Tyr's Hand";

    /// <inheritdoc />
    protected override void OnFail(Faction completingFaction) => 
      Player(PLAYER_NEUTRAL_AGGRESSIVE).RescueGroup(_rescueUnits);

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction) => 
      completingFaction.Player?.RescueGroup(_rescueUnits);
  }
}