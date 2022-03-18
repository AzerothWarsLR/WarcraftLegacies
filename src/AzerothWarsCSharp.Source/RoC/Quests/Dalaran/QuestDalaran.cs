using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;
using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Dalaran
{
  public class QuestDalaran{

  
    private const int QUEST_RESEARCH_ID = FourCC(R038);
  


    private string operator CompletionPopup( ){
      return "Dalaran outskirs are now secure, the mages will join " + this.Holder.Team.Name + ".";
    }

    private string operator CompletionDescription( ){
      return "Control of all units in Dalaran && enables Antonidas to be trained at the Altar";
    }

    private void GrantDalaran(player whichPlayer ){
      group tempGroup = CreateGroup();
      unit u;

      //Transfer all Neutral Passive units in Dalaran
      GroupEnumUnitsInRect(tempGroup, gg_rct_Dalaran, null);
      u = FirstOfGroup(tempGroup);
      while(true){
        if ( u == null){ break; }
        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)){
          UnitRescue(u, whichPlayer);
        }
        GroupRemoveUnit(tempGroup, u);
        u = FirstOfGroup(tempGroup);
      }
      GroupEnumUnitsInRect(tempGroup, gg_rct_DalaranDungeon, null);
      u = FirstOfGroup(tempGroup);
      while(true){
        if ( u == null){ break; }
        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)){
          UnitRescue(u, whichPlayer);
        }
        GroupRemoveUnit(tempGroup, u);
        u = FirstOfGroup(tempGroup);
      }
      DestroyGroup(tempGroup);
      tempGroup = null;
    }

    private void OnFail( ){
      GrantDalaran(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    private void OnComplete( ){
      SetPlayerTechResearched(Holder.Player, FourCC(R038), 1);
      GrantDalaran(this.Holder.Player);
      if (GetLocalPlayer() == this.Holder.Player){
        PlayThematicMusicBJ( "war3mapImported\\DalaranTheme.mp3" );
      }
    }

    private void OnAdd( ){
      this.Holder.ModObjectLimit(QUEST_RESEARCH_ID, 1);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Outskirts", "The territories of Dalaran are fragmented, secure the lands && protect Dalaran citizens .", "ReplaceableTextures\\CommandButtons\\BTNArcaneCastle.blp");
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n01D))));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n08M))));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n018))));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n01I))));
      this.AddQuestItem(QuestItemUpgrade.create(FourCC(h068), )h065)));
      this.AddQuestItem(QuestItemExpire.create(1445));
      this.AddQuestItem(QuestItemSelfExists.create());
      ;;
    }


  }
}
