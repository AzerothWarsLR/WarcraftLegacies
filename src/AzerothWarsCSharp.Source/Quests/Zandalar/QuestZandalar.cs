using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Zandalar
{
  public sealed class QuestZandalar : QuestData{

  
    private const int QUEST_RESEARCH_ID = FourCC("R04W")   ;//This research is given when the quest is completed
  


    protected override string CompletionPopup => "The City of Gold is now yours to command && has joined the " + this.Holder.Team.Name + ".";

    protected override string CompletionDescription => "Control of all units in Zandalar && enables the Golden Fleet to be built";

    private void OnFail( ){
      GeneralHelpers.RescueNeutralUnitsInRect(Regions.ZandalarUnlock.Rect, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      GeneralHelpers.RescueNeutralUnitsInRect(Regions.ZandalarUnlock.Rect, this.Holder.Player);
      if (GetLocalPlayer() == this.Holder.Player){
        PlayThematicMusicBJ( "war3mapImported\\ZandalarTheme.mp3" );
      }
    }

    private void OnAdd( ){
      this.Holder.ModObjectLimit(QUEST_RESEARCH_ID, 1);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("City of Gold", "We need to regain control of our land.", "ReplaceableTextures\\CommandButtons\\BTNBloodTrollMage.blp");
      this.AddQuestItem(new QuestItemResearch(FourCC("R04R"), )o03Z)));
      this.AddQuestItem(new QuestItemUpgrade(FourCC("o03Z"), )o03Y)));
      this.AddQuestItem(new QuestItemExpire(900));
      this.AddQuestItem(new QuestItemSelfExists());
      this.ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


  }
}
