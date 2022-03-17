using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;
using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Quelthalas
{
  public class QuestSilvermoon{

  
    private const int QUEST_RESEARCH_ID = FourCC(R02U);
  


    private string operator CompletionPopup( ){
      return "Silvermoon siege has been lifted, && its military is now free to assist the " + this.Holder.Team.Name + ".";
    }

    private string operator CompletionDescription( ){
      return "Control of all units in Silvermoon && enable Anasterian to be trained at the Altar";
    }

    private void GrantSilvermoon(player whichPlayer ){
      group tempGroup = CreateGroup();
      unit u;

      //Transfer all Neutral Passive units in Silvermoon
      GroupEnumUnitsInRect(tempGroup, gg_rct_SunwellAmbient, null);
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
      this.GrantSilvermoon(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    private void OnComplete( ){
      SetPlayerTechResearched(Holder.Player, FourCC(R02U), 1);
      this.GrantSilvermoon(this.Holder.Player);
      if (UnitAlive(gg_unit_h00D_2122) == true){
        SetUnitInvulnerable(LEGEND_SILVERMOON.Unit, true );
      }
      SetUnitInvulnerable(LEGEND_SUNWELL.Unit, true );
      if (GetLocalPlayer() == this.Holder.Player){
        PlayThematicMusicBJ( "war3mapImported\\SilvermoonTheme.mp3" );
      }
    }

    private void OnAdd( ){
      this.Holder.ModObjectLimit(QUEST_RESEARCH_ID, 1);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Siege of Silvermoon", "Silvermoon has been besieged by Trolls. Clear them out && destroy their city of ZulFourCC(aman.", "ReplaceableTextures\\CommandButtons\\BTNForestTrollTrapper.blp");
      this.AddQuestItem(QuestItemKillUnit.create(gg_unit_O00O_1933)) ;//Zul)jin
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n01V))));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n01L))));
      this.AddQuestItem(QuestItemUpgrade.create(FourCC(h03T), )h033)));
      this.AddQuestItem(QuestItemExpire.create(1480));
      this.AddQuestItem(QuestItemSelfExists.create());
      ;;
    }


  }
}
