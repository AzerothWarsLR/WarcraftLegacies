using AzerothWarsCSharp.Source.Libraries;
using AzerothWarsCSharp.Source.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.KulTiras
{
  public class QuestBoralus{

  
    private const int QUEST_RESEARCH_ID = FourCC(R00L)   ;//This research is given when the quest is completed
  


    protected override string CompletionPopup => 
      return "KulFourCC(Tiras has joined the war && its military is now free to assist the " + this.Holder.Team.Name + ".";
    }

    protected override string CompletionDescription => 
      return "Control of all units in KulFourCC(Tiras && enables Katherine Proodmoure to be trained at the altar";
    }

    private void OnFail( ){
      GeneralHelpers.RescueNeutralUnitsInRect(gg_rct_Kultiras, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      GeneralHelpers.RescueNeutralUnitsInRect(gg_rct_Kultiras, this.Holder.Player);
      if (GetLocalPlayer() == this.Holder.Player){
        PlayThematicMusicBJ( "war3mapImported\\KultirasTheme.mp3" );
      }
    }

    private void OnAdd( ){
      this.Holder.ModObjectLimit(QUEST_RESEARCH_ID, 1);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The City at Sea", "Proudmoore is stranded at sea. Rejoin Boralus to take control of the city.", "ReplaceableTextures\\CommandButtons\\BTNHumanShipyard.blp");
      this.AddQuestItem(QuestItemResearch.create(FourCC(R04R), )h06I)));
      this.AddQuestItem(QuestItemUpgrade.create(FourCC(h06I), )h062)));
      this.AddQuestItem(QuestItemExpire.create(900));
      this.AddQuestItem(QuestItemSelfExists.create());
      this.ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


  }
}
