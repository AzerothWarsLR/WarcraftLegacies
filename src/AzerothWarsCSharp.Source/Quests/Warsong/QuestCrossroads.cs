using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using static War3Api.Common;
using static War3Api.Blizzard;

namespace AzerothWarsCSharp.Source.Quests.Warsong
{
  public sealed class QuestCrossroads : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestCrossroads(rect rescueRect) : base("The Crossroads",
      "The Horde still needs to establish a strong strategic foothold into Kalimdor. There is an opportune crossroads nearby.",
      "ReplaceableTextures\\CommandButtons\\BTNBarracks.blp")
    {
      AddQuestItem(
        new QuestItemKillUnit(PreplacedUnitSystem.GetUnit(FourCC("nrzm")))); //Razorman Medicine Man
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n01T"))));
      AddQuestItem(new QuestItemExpire(1460));
      AddQuestItem(new QuestItemSelfExists());

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
      AdjustPlayerStateBJ(2000, Holder.Player, PLAYER_STATE_RESOURCE_LUMBER);
    }

    protected override void OnFail()
    {
      GiveCrossroads(Player(PLAYER_NEUTRAL_AGGRESSIVE));
      _rescueUnits.Clear();
    }

    protected override void OnComplete()
    {
      GiveCrossroads(Holder.Player);
      _rescueUnits.Clear();
    }
  }
}