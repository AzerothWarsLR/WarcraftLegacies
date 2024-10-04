using System.Collections.Generic;
using MacroTools;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;


namespace WarcraftLegacies.Source.Quests.Frostwolf
{
  public sealed class QuestCrossroadsFrostwolf : QuestData
  {
    private readonly List<unit> _rescueUnits;

    public QuestCrossroadsFrostwolf(Rectangle rescueRect) : base(
      "The Crossroads",
      "The Horde still needs to establish a strong strategic foothold into Kalimdor. Expand into the Barrens and claim the Crossroads.",
      @"ReplaceableTextures\CommandButtons\BTNBarracks.blp")
    {
      AddObjective(new ObjectiveControlPoint(UNIT_N01T_NORTHERN_BARRENS));
      AddObjective(new ObjectiveExpire(480, Title));
      AddObjective(new ObjectiveSelfExists());

      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
    }

    /// <inheritdoc/>
    public override string RewardFlavour => "The Crossroads have been constructed";

    /// <inheritdoc/>
    protected override string RewardDescription => "Control of the Crossroads";

    private void GiveCrossroads(player whichPlayer)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(whichPlayer);
      var wardId = FourCC("oeye");
      CreateUnit(whichPlayer, wardId, -12844, -1975, 0);
      CreateUnit(whichPlayer, wardId, -10876, -2066, 0);
      CreateUnit(whichPlayer, wardId, -11922, -824, 0);
    }

    /// <inheritdoc/>
    protected override void OnFail(Faction completingFaction)
    {
      var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
        ? Player(PLAYER_NEUTRAL_AGGRESSIVE)
        : completingFaction.Player;

      GiveCrossroads(completingFaction.Player);
    }

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      GiveCrossroads(completingFaction.Player);
      _rescueUnits.Clear();
    }
  }
}