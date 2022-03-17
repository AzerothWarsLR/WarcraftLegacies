using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;
using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Goblin
{
  public class QuestGoblinEmpire{

  
    private const int QUEST_RESEARCH_ID = FourCC(R07F)   ;//This research is given when the quest is completed
  


    private string operator CompletionPopup( ){
      return "With all the Goblin towns united, a new empire rises!";
    }

    private string operator CompletionDescription( ){
      return "Unlock the Intercontinental Artillery";
    }

    private void OnComplete( ){
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Goblin Empire", "All the Goblin syndicatesFourCC( towns must be reunited under one banner.", "ReplaceableTextures\\CommandButtons\\BTNGoblinWarZeppelin.blp");
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n01X))));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n00L))));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n07Y))));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n01E))));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n04Z))));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n05C))));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n0A6))));
      this.ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


  }
}
