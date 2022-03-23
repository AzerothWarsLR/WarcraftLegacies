using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Zandalar
{
  public sealed class QuestZandalar : QuestData{

  
    private const int QUEST_RESEARCH_ID = FourCC("R04W")   ;//This research is given when the quest is completed
  


    protected override string CompletionPopup => "The City of Gold is now yours to command && has joined the " + Holder.Team.Name + ".";

    protected override string CompletionDescription => "Control of all units in Zandalar && enables the Golden Fleet to be built";

    protected override void OnFail( ){
      RescueNeutralUnitsInRect(Regions.ZandalarUnlock.Rect, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      RescueNeutralUnitsInRect(Regions.ZandalarUnlock.Rect, Holder.Player);
      if (GetLocalPlayer() == Holder.Player){
        PlayThematicMusicBJ( "war3mapImported\\ZandalarTheme.mp3" );
      }
    }

    protected override void OnAdd( ){
      Holder.ModObjectLimit(QUEST_RESEARCH_ID, 1);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("City of Gold", "We need to regain control of our land.", "ReplaceableTextures\\CommandButtons\\BTNBloodTrollMage.blp");
      this.AddQuestItem(new QuestItemResearch(FourCC("R04R"), )o03Z)));
      this.AddQuestItem(new QuestItemUpgrade(FourCC("o03Z"), )o03Y)));
      AddQuestItem(new QuestItemExpire(900));
      AddQuestItem(new QuestItemSelfExists());
      ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


  }
}
