using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;
using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Scarlet
{
  public class QuestArathiVolunteers{

  
    private const int QUEST_RESEARCH_ID = FourCC(R089);
  


    private string operator CompletionPopup( ){
      //Todo: what fight, flavour wise? Is it the Third War?
      return "The Arathi have been convinced to join the fight.";
    }

    private string operator CompletionDescription( ){
      return "Enable to train Mounted Archers";
    }

    public  thistype ( ){
      //Todo: what fight, flavour wise? Is it the Third War?
      thistype this = thistype.allocate("Arathi Volunteers", "The men of Stromgrade should join us in the fight.", "ReplaceableTextures\\CommandButtons\\BTNNobbyMansionCastle.blp");
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n01K))));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n01Z))));
      this.ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


  }
}
