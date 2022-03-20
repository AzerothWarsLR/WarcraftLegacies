using AzerothWarsCSharp.Source.Libraries;
using AzerothWarsCSharp.Source.Libraries.MacroTools;
using AzerothWarsCSharp.Source.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Sentinels
{
  public class QuestFeathermoon{

  
    private const int RESEARCH_ID = FourCC(R06M)   ;//This research is given when the quest is completed
  


    protected override string CompletionPopup => 
      return "Feathermoon Stronghold has been relieved && has joined the Sentinels in their war effort";
    }

    protected override string CompletionDescription => 
      return "Control of all units in Feathermoon Stronghold && make Shandris && Maiev trainable at the Altar";
    }

    private void GrantFeathermoon(player whichPlayer ){
      group tempGroup = CreateGroup();
      unit u;

      //Transfer all Neutral Passive units in Feathermoon
      GroupEnumUnitsInRect(tempGroup, gg_rct_FeathermoonUnlock, null);
      u = FirstOfGroup(tempGroup);
      while(true){
        if ( u == null){ break; }
        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)){
          GeneralHelpers.UnitRescue(u, whichPlayer);
        }
        GroupRemoveUnit(tempGroup, u);
        u = FirstOfGroup(tempGroup);
      }
      DestroyGroup(tempGroup);
      tempGroup = null;
    }

    private void OnFail( ){
      GrantFeathermoon(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      GrantFeathermoon(this.Holder.Player);
      AdjustPlayerStateBJ( 300, this.Holder.Player, PLAYER_STATE_RESOURCE_LUMBER );
      AdjustPlayerStateBJ( 300, this.Holder.Player, PLAYER_STATE_RESOURCE_GOLD );
      if (GetLocalPlayer() == this.Holder.Player){
        PlayThematicMusicBJ( "war3mapImported\\SentinelTheme.mp3" );
      }
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Feathermoon Stronghold", "Feathermoon Stronghold stood guard for ten thousand years, it is time to relieve the guards from their duty.", "ReplaceableTextures\\CommandButtons\\BTNBearDen.blp");
      this.AddQuestItem(QuestItemLegendReachRect.create(LEGEND_TYRANDE, gg_rct_FeathermoonUnlock, "Feathermoon Stronghold"));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.GetFromUnitType(FourCC(n01R))));
      this.AddQuestItem(QuestItemUpgrade.create(FourCC(n06P), )n06J)));
      this.AddQuestItem(QuestItemExpire.create(1485));
      this.AddQuestItem(QuestItemSelfExists.create());
      this.ResearchId = RESEARCH_ID;
      ;;
    }


  }
}
