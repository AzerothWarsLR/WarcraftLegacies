
using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Quelthalas
{
  public class QuestStayLoyal{


    private boolean operator Global( ){
      return true;
    }

    protected override string CompletionPopup => 
      return "The Blood Elves stay loyal to Illidan";
    }

    protected override string CompletionDescription => 
      return "Stay allied to Illidan";
    }

    protected override void OnComplete(){
      GREAT_TREACHERY.Progress = QUEST_PROGRESS_FAILED;
      SUMMON_KIL.Progress = QUEST_PROGRESS_FAILED;
      UnitRemoveAbilityBJ( FourCC(A0IK), LEGEND_KAEL.Unit);
      UnitRemoveAbilityBJ( FourCC(A0IF), LEGEND_KAEL.Unit);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Refuse KilFourCC(Jaeden)s Offer", "Kil)jaeden has approached Kael with an offer of power && salvation. He should refuse it && resist the temptation of Fel power.", "ReplaceableTextures\\CommandButtons\\BTNDemonHunter2blp");
      this.AddQuestItem(QuestItemCastSpell.create(FourCC(A0IK), true));
      this.AddQuestItem(QuestItemLegendLevel.create(LEGEND_KAEL, 6));
      ;;
    }


  }
}
