
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Quelthalas
{
  public sealed class QuestStayLoyal : QuestData{


    private bool operator Global( ){
      return true;
    }

    protected override string CompletionPopup => "The Blood Elves stay loyal to Illidan";

    protected override string CompletionDescription => "Stay allied to Illidan";

    protected override void OnComplete(){
      GREAT_TREACHERY.Progress = QUEST_PROGRESS_FAILED;
      SUMMON_KIL.Progress = QUEST_PROGRESS_FAILED;
      UnitRemoveAbilityBJ( FourCC("A0IK"), LEGEND_KAEL.Unit);
      UnitRemoveAbilityBJ( FourCC("A0IF"), LEGEND_KAEL.Unit);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Refuse KilFourCC("Jaeden")s Offer", "Kil)jaeden has approached Kael with an offer of power && salvation. He should refuse it && resist the temptation of Fel power.", "ReplaceableTextures\\CommandButtons\\BTNDemonHunter2blp");
      AddQuestItem(new QuestItemCastSpell(FourCC("A0IK"), true));
      this.AddQuestItem(new QuestItemLegendLevel(LEGEND_KAEL, 6));
      
    }


  }
}
