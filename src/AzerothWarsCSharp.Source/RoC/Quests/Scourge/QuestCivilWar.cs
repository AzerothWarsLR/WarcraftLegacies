using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Scourge
{
  public class QuestCivilWar{


    private boolean Global( ){
      return true;
    }

    private string operator CompletionPopup( ){
      return "The Lich King has rebelled against his demon masters";
    }

    private string operator CompletionDescription( ){
      return "Unally from the Legion team";
    }

    private void OnComplete( ){
      this.Holder.Team = TEAM_SCOURGE;
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Civil War", "The Lich King wants to break free from his Demon Master, but he will need a champion first", "ReplaceableTextures\\CommandButtons\\BTNTheLichKingQuest.blp");
      this.AddQuestItem(QuestItemResearch.create(FourCC(R07W), )u000)));
      this.AddQuestItem(QuestItemControlLegend.create(LEGEND_ARTHAS, false));
      this.AddQuestItem(QuestItemTime.create(900));
      ;;
    }


  }
}
