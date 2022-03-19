using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Zandalar
{
  public class QuestZandalar{

  
    private const int QUEST_RESEARCH_ID = FourCC(R04W)   ;//This research is given when the quest is completed
  


    protected override string CompletionPopup => 
      return "The City of Gold is now yours to command && has joined the " + this.Holder.Team.Name + ".";
    }

    protected override string CompletionDescription => 
      return "Control of all units in Zandalar && enables the Golden Fleet to be built";
    }

    private void OnFail( ){
      RescueNeutralUnitsInRect(gg_rct_ZandalarUnlock, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      RescueNeutralUnitsInRect(gg_rct_ZandalarUnlock, this.Holder.Player);
      if (GetLocalPlayer() == this.Holder.Player){
        PlayThematicMusicBJ( "war3mapImported\\ZandalarTheme.mp3" );
      }
    }

    private void OnAdd( ){
      this.Holder.ModObjectLimit(QUEST_RESEARCH_ID, 1);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("City of Gold", "We need to regain control of our land.", "ReplaceableTextures\\CommandButtons\\BTNBloodTrollMage.blp");
      this.AddQuestItem(QuestItemResearch.create(FourCC(R04R), )o03Z)));
      this.AddQuestItem(QuestItemUpgrade.create(FourCC(o03Z), )o03Y)));
      this.AddQuestItem(QuestItemExpire.create(900));
      this.AddQuestItem(QuestItemSelfExists.create());
      this.ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


  }
}
