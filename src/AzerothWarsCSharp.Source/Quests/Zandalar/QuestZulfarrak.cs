using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Zandalar
{
  public sealed class QuestZulfarrak : QuestData{

  
    private static readonly int GahzrillaResearch = FourCC("R02F");
    private static readonly int GahzrillaId = FourCC("H06Q");
  


    protected override string CompletionPopup => "ZulFourCC("farrak Has fallen. The Sandfury trolls Lend their Might to The " + this.Holder.Team.Name + ", you Can train Storm Wyrms && Gahz")rilla awakens from its slumber.";

    protected override string CompletionDescription => "Control of ZulFourCC("farrak, 300 gold _tribute, _enable to Train Storm Wyrm && you Can summon The hero Gahz")rilla from the Altar of Conquerors";

    protected override void OnComplete(){
      unit u;
      group tempGroup;
      tempGroup = CreateGroup();
      GroupEnumUnitsInRect(tempGroup, Regions.Zulfarrak.Rect, null);
      u = FirstOfGroup(tempGroup);
      while(true){
        if ( u == null){ break; }
        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE) || GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_AGGRESSIVE)){
          if (IsUnitType(u, UNIT_TYPE_HERO)){
            KillUnit(u);
          }else {
            UnitRescue(u, Holder.Player);
          }
        }
        GroupRemoveUnit(tempGroup, u);
        u = FirstOfGroup(tempGroup);
      }
      DestroyGroup(tempGroup);
      SetPlayerTechResearched(Holder.Player, GahzrillaResearch, 1);
      AdjustPlayerStateBJ( 300, Holder.Player, PLAYER_STATE_RESOURCE_GOLD );
      SetUnitOwner(LEGEND_ZULFARRAK.Unit, Holder.Player, true);
    }

    protected override void OnAdd( ){
      Holder.ModObjectLimit(GahzrillaResearch, UNLIMITED);
      Holder.ModObjectLimit(GahzrillaId, 1);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Fury of the Sands", "The Sandfury Trolls of ZulFourCC("farrak are openly hostile to visitors, but they share a common heritage with the Zandalari Trolls. An adequate display of force could bring them around.", "ReplaceableTextures\\CommandButtons\\BTNDarkTroll.blp"");
      AddQuestItem(new QuestItemControlLegend(LEGEND_ZULFARRAK, false));
      
    }


  }
}
