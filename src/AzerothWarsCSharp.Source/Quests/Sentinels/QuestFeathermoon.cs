using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Sentinels
{
  public sealed class QuestFeathermoon : QuestData{

  
    private const int RESEARCH_ID = FourCC("R06M")   ;//This research is given when the quest is completed
  


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
      this.AddQuestItem(new QuestItemLegendReachRect(LEGEND_TYRANDE, gg_rct_FeathermoonUnlock, "Feathermoon Stronghold"));
      this.AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n01R"))));
      this.AddQuestItem(new QuestItemUpgrade(FourCC("n06P"), )n06J)));
      this.AddQuestItem(new QuestItemExpire(1485));
      this.AddQuestItem(new QuestItemSelfExists());
      this.ResearchId = RESEARCH_ID;
      ;;
    }


  }
}
