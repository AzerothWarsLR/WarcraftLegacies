using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;
using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Draenei
{
  public class QuestBrokenOne{

  
    private const int QUESTRESEARCH_ID = FourCC(R083)   ;//This research is given when the quest is completed
  



    private string operator CompletionPopup( ){
      return "The hero Nobundo is now trainable at the Altar";
    }

    private string operator CompletionDescription( ){
      return "Nobundo will join the survivors on the Exodar";
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Broken One", "The great shaman Nobundo is fighting to enable Velen && most of the Draenei to escape. If the Draenei hold out long enough, he might have time to join the survivors aboard the Exodar", "ReplaceableTextures\\CommandButtons\\BTNAkamanew.blp");
      this.AddQuestItem(QuestItemTime.create(720));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n02O))));
      this.ResearchId = QUESTRESEARCH_ID;
      ;;
    }


  }
}
