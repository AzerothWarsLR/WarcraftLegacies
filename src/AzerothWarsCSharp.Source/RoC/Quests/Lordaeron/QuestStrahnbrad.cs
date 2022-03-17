public class QuestStrahnbrad{



    private string operator CompletionPopup( ){
      return "Strahnbrad has been liberated.";
    }

    private string operator CompletionDescription( ){
      return "Control of all buildings in Strahnbrad";
    }

    private void OnFail( ){
      RescueNeutralUnitsInRect(gg_rct_StrahnbradUnlock, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    private void OnComplete( ){
      RescueNeutralUnitsInRect(gg_rct_StrahnbradUnlock, this.Holder.Player);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Defense of Strahnbrad", "The Strahnbrad is under attack by some brigands, clear them out", "ReplaceableTextures\\CommandButtons\\BTNFarm.blp");
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n01C))));
      this.AddQuestItem(QuestItemExpire.create(1170));
      this.AddQuestItem(QuestItemSelfExists.create());
      ;;
    }


}
