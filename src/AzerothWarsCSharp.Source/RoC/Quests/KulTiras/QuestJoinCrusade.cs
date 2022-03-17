
public class QuestJoinCrusade{

  
    private const int QUEST_RESEARCH_ID = FourCC(R06U)   ;//This research is given when the quest is completed
  



    private string operator CompletionPopup( ){
      return "Kul Tiras has joined the Scarlet Crusade";
    }

    private string operator CompletionDescription( ){
      return "Unlock Order Inquisitor && join the Scarlet Crusade";
    }

    private void OnComplete( ){
      UnitRemoveAbilityBJ( FourCC(A0JB), LEGEND_ADMIRAL.Unit);
      this.Holder.Team = TEAM_SCARLET;
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Join the Crusade", "Daelin Proudmoore sees the plight of the Scarlet Crusade. As fellow human survivors of horrible war, they should join forces with KulFourCC(tiras.", "ReplaceableTextures\\CommandButtons\\BTNDivine_Reckoning_Icon.blp");
      this.AddQuestItem(QuestItemCastSpell.create(FourCC(A0JB), true));
      this.ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


}
