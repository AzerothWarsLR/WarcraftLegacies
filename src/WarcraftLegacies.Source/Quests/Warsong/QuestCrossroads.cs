using System.Collections.Generic;
using MacroTools;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using MacroTools.Wrappers;
using WCSharp.Shared.Data;
using static War3Api.Common;


namespace WarcraftLegacies.Source.Quests.Warsong
{
  public sealed class QuestCrossroads : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestCrossroads(Rectangle rescueRect) : base("The Crossroads",
      "The Horde still needs to establish a strong strategic foothold into Kalimdor. There is an opportune crossroads nearby.",
      "ReplaceableTextures\\CommandButtons\\BTNBarracks.blp")
    {
      AddObjective(
        new ObjectiveKillUnit(PreplacedUnitSystem.GetUnit(FourCC("nrzm"), rescueRect.Center))); //Razorman Medicine Man
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(FourCC("n01T"))));
      AddObjective(new ObjectiveExpire(1460));
      AddObjective(new ObjectiveSelfExists());

      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rescueRect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
    }

    protected override string CompletionPopup => "The Crossroads have been constructed.";

    protected override string RewardDescription => "Control of the Crossroads";

    private void GiveCrossroads(player whichPlayer)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(whichPlayer);
      var wardId = FourCC("oeye");
      CreateUnit(whichPlayer, wardId, -12844, -1975, 0);
      CreateUnit(whichPlayer, wardId, -10876, -2066, 0);
      CreateUnit(whichPlayer, wardId, -11922, -824, 0);
      whichPlayer.AdjustPlayerState(PLAYER_STATE_RESOURCE_LUMBER, 2000);
    }

    protected override void OnFail(Faction completingFaction)
    {
      GiveCrossroads(Player(PLAYER_NEUTRAL_AGGRESSIVE));
      _rescueUnits.Clear();
    }

    protected override void OnComplete(Faction completingFaction)
    {
      GiveCrossroads(completingFaction.Player);
      _rescueUnits.Clear();
    }
  }
}