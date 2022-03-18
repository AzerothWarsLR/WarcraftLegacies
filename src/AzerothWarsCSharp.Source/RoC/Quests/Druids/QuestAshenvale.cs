using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;
using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Druids
{
  public class QuestAshenvale{

  
    private const int RESEARCH_ID = FourCC(R06R)   ;//This research is given when the quest is completed
  


    private string operator CompletionPopup( ){
      return "Ashenvale is under control && Cenarius can now be awaken";
    }

    private string operator CompletionDescription( ){
      return "Control of all units in Ashenvale && make Cenarius trainable at the Altar";
    }

    private void GrantAshenvale(player whichPlayer ){
      group tempGroup = CreateGroup();
      unit u;

      //Transfer all Neutral Passive units in Ashenvale
      GroupEnumUnitsInRect(tempGroup, gg_rct_AshenvaleUnlock, null);
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
      GrantAshenvale(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    private void OnComplete( ){
      GrantAshenvale(this.Holder.Player);
      if (GetLocalPlayer() == this.Holder.Player){
        PlayThematicMusicBJ( "war3mapImported\\DruidTheme.mp3" );
      }
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Spirits of Ashenvale", "The forest needs healing. Regain control of it to summon itFourCC(s Guardian, the Demigod Cenarius", "ReplaceableTextures\\CommandButtons\\BTNKeeperC.blp");
      this.AddQuestItem(QuestItemLegendReachRect.create(LEGEND_MALFURION, gg_rct_AshenvaleUnlock, "Ashenvale"));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n07C))));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n01Q))));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n08U))));
      this.AddQuestItem(QuestItemUpgrade.create(FourCC(etoa), )etol)));
      this.AddQuestItem(QuestItemExpire.create(1440));
      this.AddQuestItem(QuestItemSelfExists.create());
      this.ResearchId = RESEARCH_ID;
      ;;
    }


  }
}
