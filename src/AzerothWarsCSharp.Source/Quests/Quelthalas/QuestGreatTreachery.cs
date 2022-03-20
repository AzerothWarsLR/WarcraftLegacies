
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Quelthalas
{
  public class QuestGreatTreachery{

  
    private const int QUEST_RESEARCH_ID = FourCC(R075)   ;//This research is given when the quest is completed
  


    private bool operator Global( ){
      return true;
    }

    protected override string CompletionPopup => 
      return "The Blood Elves have joined the Burning Legion";
    }

    protected override string CompletionDescription => 
      return "Unlock the summon KilFourCC(jaeden quest && join the Burning Legion team";
    }

    protected override void OnComplete(){
      STAY_LOYAL.Progress = QUEST_PROGRESS_FAILED;
      UnitRemoveAbilityBJ( FourCC(A0IF), LEGEND_KAEL.Unit);
      UnitRemoveAbilityBJ( FourCC(A0IK), LEGEND_KAEL.Unit);
      RemoveUnit(LEGEND_LORTHEMAR.Unit);
      FACTION_QUELTHALAS.ModObjectLimit(FourCC(H02E),-UNLIMITED)       ;//Lorthemar
      this.Holder.Team = TEAM_LEGION;
      SUMMON_KIL.Progress = QUEST_PROGRESS_INCOMPLETE;
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Great Treachery", "KilFourCC(jaeden has approached Kael with an offer of power && salvation for his people. Only by accepting will his hunger for magic by satiated.", "ReplaceableTextures\\CommandButtons\\BTNFelKaelthas.blp");
      this.AddQuestItem(QuestItemCastSpell.create(FourCC(A0IF), true));
      this.AddQuestItem(QuestItemLegendLevel.create(LEGEND_KAEL, 6));
      this.ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


  }
}
