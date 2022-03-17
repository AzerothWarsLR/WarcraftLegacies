using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Goblin
{
  public class QuestBusinessExpansion{

  
    private const int QUEST_RESEARCH_ID = FourCC(R07G)   ;//This research is given when the quest is completed
  


    private string operator CompletionPopup( ){
      return "You can now build shipyards && ships";
    }

    private string operator CompletionDescription( ){
      return "The shipyard will be buildable";
    }

    private void GrantGadetzan(player whichPlayer ){
      group tempGroup = CreateGroup();
      unit u;

      //Transfer all Neutral Passive units in Gadetzan
      GroupEnumUnitsInRect(tempGroup, gg_rct_GadgetUnlock, null);
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
      this.GrantGadetzan(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    private void OnComplete( ){
      this.GrantGadetzan(this.Holder.Player);
      if (GetLocalPlayer() == this.Holder.Player){
        PlayThematicMusicBJ( "war3mapImported\\GoblinTheme.mp3" );
      }
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Business Expansion", "Trade Prince Gallywix will need a great amount of wealth to rule the future Goblin Empire; he needs to expand his business all over the world quickly.", "ReplaceableTextures\\CommandButtons\\BTNGoblinPrince.blp");
      this.AddQuestItem(QuestItemTrain.create(FourCC(nzep),)o04M), 16));
      this.AddQuestItem(QuestItemTrain.create(FourCC(o04S),)o04M), 10));
      this.ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


  }
}
