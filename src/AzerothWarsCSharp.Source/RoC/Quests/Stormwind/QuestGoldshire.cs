public class QuestGoldshire{


    private string operator CompletionPopup( ){
      return "The Gnolls have been defeated, Goldshire is safe.";
    }

    private string operator CompletionDescription( ){
      return "Control of all units in Goldshire";
    }

    private void GrantGoldshire(player whichPlayer ){
      group tempGroup = CreateGroup();
      unit u;

      //Transfer all Neutral Passive units in Goldshire
      GroupEnumUnitsInRect(tempGroup, gg_rct_ElwinForestAmbient, null);
      u = FirstOfGroup(tempGroup);
      while(true){
      if ( u == null){ break; }
        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)){
          UnitRescue(u, whichPlayer);
        }
        GroupRemoveUnit(tempGroup, u);
        u = FirstOfGroup(tempGroup);
      }
      DestroyGroup(tempGroup);
      tempGroup = null;
    }

    private void OnFail( ){
      this.GrantGoldshire(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    private void OnComplete( ){
      this.GrantGoldshire(this.Holder.Player);
    }


    public  thistype ( ){
      thistype this = thistype.allocate("The Scourge of Elwynn", "Hogger && his pack have taken over Goldshire, clear them out!", "ReplaceableTextures\\CommandButtons\\BTNGnoll.blp");
      this.AddQuestItem(QuestItemKillUnit.create(gg_unit_n021_2624)) ;//Hogger
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n00Z))));
      this.AddQuestItem(QuestItemExpire.create(1335));
      this.AddQuestItem(QuestItemSelfExists.create());
      ;;
    }


}
