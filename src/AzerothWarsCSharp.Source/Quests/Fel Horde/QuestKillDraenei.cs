using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;

namespace AzerothWarsCSharp.Source.Quests.Fel_Horde
{
  public sealed class QuestKillDraenei : QuestData
  {
    public QuestKillDraenei() : base("The Shattrah Massacre",
      "The Draenei race existence insults the Fel Horde demon masters, slaughter them all ",
      "ReplaceableTextures\\CommandButtons\\BTNChaosWolfRider.blp")
    {
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n09X"))));
      AddQuestItem(new QuestItemLegendDead(LegendDraenei.LegendExodarship));
      AddQuestItem(QuestItemSelfExists);
      ;
      ;
    }


    protected override string CompletionPopup =>
      "The Draenei have been eliminated from Outland && their gold mine is ours.";

    protected override string CompletionDescription =>
      "The Draenei rich gold mine in Tempest Keep, the faster we destroy them, the more gold will be left";

    protected override void OnComplete()
    {
      group tempGroup = CreateGroup();
      unit u;

      AdjustPlayerStateBJ(500, Holder.Player, PLAYER_STATE_RESOURCE_GOLD);
      AdjustPlayerStateBJ(500, Holder.Player, PLAYER_STATE_RESOURCE_LUMBER);

      GroupEnumUnitsInRect(tempGroup, Regions.InstanceOutland.Rect, null);
      u = FirstOfGroup(tempGroup);
      while (true)
      {
        if (u == null) break;
        if (GetOwningPlayer(u) == FACTION_DRAENEI.Player)
          if (IsUnitType(u, UNIT_TYPE_STRUCTURE) && !IsUnitType(u, UNIT_TYPE_ANCIENT))
            KillUnit(u);
        GroupRemoveUnit(tempGroup, u);
        u = FirstOfGroup(tempGroup);
      }

      DestroyGroup(tempGroup);
      
    }
  }
}