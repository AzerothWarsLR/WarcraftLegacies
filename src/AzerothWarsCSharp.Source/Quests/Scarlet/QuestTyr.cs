using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Scarlet
{
  public sealed class QuestTyr : QuestData{

 
    private const int RESEARCH_ID = FourCC("R03R")   ;//This research is given when the quest is completed
  


    protected override string CompletionPopup => "TyrFourCC(s Hand has joined the war && its military is now free to assist the " + Holder.Team.Name + ".";

    protected override string CompletionDescription => "Control of all units in TyrFourCC(s Hand";

    protected override void OnFail( ){
      RescueNeutralUnitsInRect(Regions.TyrUnlock.Rect, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      RescueNeutralUnitsInRect(Regions.TyrUnlock.Rect, Holder.Player);
    }

    protected override void OnAdd( ){
      Holder.ModObjectLimit(RESEARCH_ID, 1);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Scarlet Enclave", "The legions at TyrFourCC("s Hand remain neutral for the moment, but when the time is right, they will align themselves with the Scarlet Crusade.", "ReplaceableTextures\\CommandButtons\\BTNCastle.blp"");
      AddQuestItem(new QuestItemTime(1000));
      AddQuestItem(new QuestItemSelfExists());
      ResearchId = RESEARCH_ID;
      ;;
    }


  }
}
