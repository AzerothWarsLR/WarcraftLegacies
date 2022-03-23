using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Scarlet
{
  public class QuestArathiVolunteers{

  
    private const int QUEST_RESEARCH_ID = FourCC("R089");
  


    protected override string CompletionPopup => 
      //Todo: what fight, flavour wise? Is it the Third War?
      return "The Arathi have been convinced to join the fight.";
    }

    protected override string CompletionDescription => 
      return "Enable to train Mounted Archers";
    }

    public  thistype ( ){
      //Todo: what fight, flavour wise? Is it the Third War?
      thistype this = thistype.allocate("Arathi Volunteers", "The men of Stromgrade should join us in the fight.", "ReplaceableTextures\\CommandButtons\\BTNNobbyMansionCastle.blp");
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.GetFromUnitType(FourCC("n01K"))));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.GetFromUnitType(FourCC("n01Z"))));
      this.ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


  }
}
