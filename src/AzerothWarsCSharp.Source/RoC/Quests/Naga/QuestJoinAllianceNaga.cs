public class QuestJoinAllianceNaga{



    private string operator CompletionPopup( ){
      return "The Illidari have joined the Alliance";
    }

    private string operator CompletionDescription( ){
      return "Join the Alliance team";
    }

    private void OnComplete( ){
      UnitRemoveAbilityBJ( FourCC(A0IG), LEGEND_ALTRUIS.Unit);
      this.Holder.Team = TEAM_ALLIANCE;
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Join the Alliance", "The Alliance has invited the Night Elves to join them in the face of a looming world threat.", "ReplaceableTextures\\CommandButtons\\BTNalliance.blp");
      this.AddQuestItem(QuestItemCastSpell.create(FourCC(A0IG), true));
      this.AddQuestItem(QuestItemControlLegend.create(LEGEND_ALTRUIS, true));
      this.AddQuestItem(QuestItemResearch.create(FourCC(R062), )n055)));
      ;;
    }


}
