using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Scarlet
{
  public sealed class QuestArathiVolunteers : QuestData{

  
    private static readonly int QuestResearchId = FourCC("R089");
  


    protected override string CompletionPopup =>
    return "The Arathi have been convinced to join the fight.";
    }

    protected override string CompletionDescription => "Enable to train Mounted Archers";

    public  thistype ( ){
      thistype this = thistype.allocate("Arathi Volunteers", "The men of Stromgrade should join us in the fight.", "ReplaceableTextures\\CommandButtons\\BTNNobbyMansionCastle.blp");
      this.AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n01K"))));
      this.AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n01Z"))));
      this.ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


  }
}
