using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

using static War3Api.Common;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;

namespace AzerothWarsCSharp.Source.Quests.Stormwind
{
  public sealed class QuestLakeshire : QuestData
  {
    public QuestLakeshire(unit ogreLordToKill) : base("Marauding Ogres", "The town of Lakeshire is invaded by Ogres, wipe them out!",
      "ReplaceableTextures\\CommandButtons\\BTNOgreLord.blp")
    {
      AddQuestItem(new QuestItemKillUnit(ogreLordToKill));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n011"))));
      AddQuestItem(new QuestItemExpire(1427));
      AddQuestItem(new QuestItemSelfExists());
    }
    
    protected override string CompletionPopup =>
      "Lakeshire has been liberated, and its military is now free to assist the " + Holder.Team.Name + ".";

    protected override string RewardDescription => "Control of all units in Lakeshire";

    private static void GrantLakeshire(player whichPlayer)
    {
      group tempGroup = CreateGroup();

      //Transfer all Neutral Passive units in Lakeshire
      GroupEnumUnitsInRect(tempGroup, Regions.LakeshireUnlock.Rect, null);
      unit u = FirstOfGroup(tempGroup);
      while (true)
      {
        if (u == null) break;
        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)) UnitRescue(u, whichPlayer);
        GroupRemoveUnit(tempGroup, u);
        u = FirstOfGroup(tempGroup);
      }

      DestroyGroup(tempGroup);
      
    }

    protected override void OnFail()
    {
      GrantLakeshire(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete()
    {
      GrantLakeshire(Holder.Player);
    }
  }
}