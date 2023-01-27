using System.Collections.Generic;
using MacroTools;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;


namespace WarcraftLegacies.Source.Quests.Warsong
{
  public sealed class QuestCrossroads : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestCrossroads(Rectangle rescueRect, PreplacedUnitSystem preplacedUnitSystem) : base("The Crossroads",
      "The Horde still needs to establish a strong strategic foothold into Kalimdor. Expand into the Barrens and claim the Crossroads.",
      "ReplaceableTextures\\CommandButtons\\BTNBarracks.blp")
    {
      AddObjective(
        new ObjectiveKillUnit(preplacedUnitSystem.GetUnit(FourCC("nrzm"), rescueRect.Center))); //Razorman Medicine Man
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N01T_NORTHERN_BARRENS_15GOLD_MIN)));
      AddObjective(new ObjectiveExpire(1460));
      AddObjective(new ObjectiveSelfExists());
      Required = true;

      foreach (var unit in CreateGroup().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
    }

    /// <inheritdoc/>
    protected override string RewardFlavour => "The Crossroads have been constructed. You have received 2000 Lumber.";

    /// <inheritdoc/>
    protected override string RewardDescription => "Control of the Crossroads, +2000 Lumber";

    private void GiveCrossroads(player whichPlayer)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(whichPlayer);
      var wardId = FourCC("oeye");
      CreateUnit(whichPlayer, wardId, -12844, -1975, 0);
      CreateUnit(whichPlayer, wardId, -10876, -2066, 0);
      CreateUnit(whichPlayer, wardId, -11922, -824, 0);
      whichPlayer.AdjustPlayerState(PLAYER_STATE_RESOURCE_LUMBER, 2000);
    }

    /// <inheritdoc/>
    protected override void OnFail(Faction completingFaction)
    {
      GiveCrossroads(Player(PLAYER_NEUTRAL_AGGRESSIVE));
      _rescueUnits.Clear();
    }

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      GiveCrossroads(completingFaction.Player);
      _rescueUnits.Clear();
    }
  }
}