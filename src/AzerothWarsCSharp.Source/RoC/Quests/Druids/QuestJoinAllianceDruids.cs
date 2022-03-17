public class QuestJoinAllianceDruid{



    private string operator CompletionPopup( ){
      return "The Druids have joined the Alliance";
    }

    private string operator CompletionDescription( ){
      return "Join the Alliance team";
    }


    private void OnComplete( ){
      UnitRemoveAbilityBJ( FourCC(A0IG), LEGEND_MALFURION.Unit);
      this.Holder.Team = TEAM_ALLIANCE;
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Join the Alliance", "With a world ending threat happening, the Alliance has reached to the Night Elves to join them", "ReplaceableTextures\\CommandButtons\\BTNalliance.blp");
      this.AddQuestItem(QuestItemCastSpell.create(FourCC(A0IG), true));
      ;;
    }


}
