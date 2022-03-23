using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Fel_Horde
{
  public sealed class QuestHellfire : QuestData{

  
    private static readonly int QuestResearchId = FourCC("R00P");
  


    protected override string CompletionPopup => "Hellfire Citadel has been subjugated, && its military is now free to assist the " + Holder.Team.Name + ".";

    protected override string CompletionDescription => "Control of all units in Hellfire Citadel && enable Kargath to be trained at the altar";

    private void GrantHellfire(player whichPlayer ){
      group tempGroup = CreateGroup();
      unit u;

      //Transfer all Neutral Passive units in Hellfire Citadel
      GroupEnumUnitsInRect(tempGroup, Regions.HellfireUnlock.Rect, null);
      u = FirstOfGroup(tempGroup);
      while(true){
        if ( u == null){ break; }
        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_AGGRESSIVE)){
          UnitRescue(u, whichPlayer);
        }
        GroupRemoveUnit(tempGroup, u);
        u = FirstOfGroup(tempGroup);
      }
      DestroyGroup(tempGroup);
      tempGroup = null;
    }

    protected override void OnComplete(){
      UnitRescue(gg_unit_n081_0882, FACTION_FEL_HORDE.Player);
      UnitRescue(gg_unit_n081_0717, FACTION_FEL_HORDE.Player);
      SetPlayerTechResearched(Holder.Player, FourCC("R00P"), 1);
      GrantHellfire(Holder.Player);
      if (GetLocalPlayer() == Holder.Player){
        PlayThematicMusicBJ( "war3mapImported\\FelTheme.mp3" );
      }
    }

    protected override void OnFail( ){
      GrantHellfire(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnAdd( ){
      Holder.ModObjectLimit(QuestResearchId, 1);
    }

    public  QuestHellfire ( ){
      thistype this = thistype.allocate("The Citadel", "The clans holding Hellfire Citadel do !respect Kargath authority yet, destroy Murmur to finally establish Magtheridon as the undisputable king of Outland", "ReplaceableTextures\\CommandButtons\\BTNFelOrcFortress.blp");
      AddQuestItem(new QuestItemLegendDead(LEGEND_EXODARSHIP));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n01J"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n02N"))));
      this.AddQuestItem(new QuestItemUpgrade(FourCC("o030"), )o02Y)));
      AddQuestItem(new QuestItemExpire(1450));
      AddQuestItem(QuestItemSelfExists);
      ;;
    }


  }
}
