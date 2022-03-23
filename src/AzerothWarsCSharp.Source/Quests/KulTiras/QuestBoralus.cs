using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.KulTiras
{
  public sealed class QuestBoralus : QuestData{

  
    private const int QUEST_RESEARCH_ID = FourCC("R00L")   ;//This research is given when the quest is completed
  


    protected override string CompletionPopup => "KulFourCC(Tiras has joined the war && its military is now free to assist the " + Holder.Team.Name + ".";

    protected override string CompletionDescription => "Control of all units in KulFourCC(Tiras && enables Katherine Proodmoure to be trained at the altar";

    protected override void OnFail( ){
      RescueNeutralUnitsInRect(Regions.Kultiras.Rect, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      RescueNeutralUnitsInRect(Regions.Kultiras.Rect, Holder.Player);
      if (GetLocalPlayer() == Holder.Player){
        PlayThematicMusicBJ( "war3mapImported\\KultirasTheme.mp3" );
      }
    }

    private void OnAdd( ){
      Holder.ModObjectLimit(QUEST_RESEARCH_ID, 1);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The City at Sea", "Proudmoore is stranded at sea. Rejoin Boralus to take control of the city.", "ReplaceableTextures\\CommandButtons\\BTNHumanShipyard.blp");
      this.AddQuestItem(new QuestItemResearch(FourCC("R04R"), )h06I)));
      this.AddQuestItem(new QuestItemUpgrade(FourCC("h06I"), )h062)));
      AddQuestItem(new QuestItemExpire(900));
      AddQuestItem(new QuestItemSelfExists());
      ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


  }
}
