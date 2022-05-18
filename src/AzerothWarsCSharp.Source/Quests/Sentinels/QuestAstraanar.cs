using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using AzerothWarsCSharp.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;
using static War3Api.Blizzard;

namespace AzerothWarsCSharp.Source.Quests.Sentinels
{
  public sealed class QuestAstranaar : QuestData
  {
    private readonly List<unit> _rescueUnits = new();

    public QuestAstranaar(List<Rectangle> rescueRects) : base("Astranaar Stronghold",
      "Darkshore is under attack by some Murloc. We should deal with them swiftly and){ make for the Astranaar Outpost. Clearing the Murlocs will also reestablish communication with Darnassus.",
      "ReplaceableTextures\\CommandButtons\\BTNMurloc.blp")
    {
      AddQuestItem(new QuestItemLegendReachRect(LegendSentinels.legendTyrande, Regions.AstranaarUnlock,
        "Astranaar Outpost"));
      AddQuestItem(new QuestItemControlPoint(ControlPointManager.GetFromUnitType(FourCC("n02U"))));
      AddQuestItem(new QuestItemExpire(1430));
      AddQuestItem(new QuestItemSelfExists());

      foreach (var rectangle in rescueRects)
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(rectangle.Rect).EmptyToList())
        if (GetOwningPlayer(unit) == Player(PLAYER_NEUTRAL_PASSIVE))
        {
          SetUnitInvulnerable(unit, true);
          _rescueUnits.Add(unit);
        }
    }

    protected override string CompletionPopup =>
      "Astranaar has been relieved and has joined the Sentinels in their war effort";

    protected override string RewardDescription => "Control of all units in Astranaar Outpost and Darnassus";

    protected override void OnFail()
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete()
    {
      foreach (var unit in _rescueUnits) unit.Rescue(Holder.Player);
      AdjustPlayerStateBJ(200, Holder.Player, PLAYER_STATE_RESOURCE_LUMBER);
      AdjustPlayerStateBJ(100, Holder.Player, PLAYER_STATE_RESOURCE_GOLD);
    }
  }
}