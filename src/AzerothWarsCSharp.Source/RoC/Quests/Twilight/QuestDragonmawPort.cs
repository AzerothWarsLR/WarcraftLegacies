public class QuestDragonmawPort{


    private string operator CompletionPopup( ){
      return "Dragonmaw Port has fallen under our control && its military is now free to assist the " + this.Holder.Team.Name + ".";
    }

    private string operator CompletionDescription( ){
      return "Control of all buildings in Dragonmaw Port";
    }

    private void GrantDragonmawPort(player whichPlayer ){
      group tempGroup = CreateGroup();
      unit u;

      //Transfer all Neutral Passive units in DragonmawPort
      GroupEnumUnitsInRect(tempGroup, gg_rct_DragonmawUnlock, null);
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
      this.GrantDragonmawPort(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    private void OnComplete( ){
      this.GrantDragonmawPort(this.Holder.Player);
    }

    private void OnAdd( ){
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Dragonmaw Port", "The Dragonmaw Port will be the perfect staging ground of the invasion of Azeroth", "ReplaceableTextures\\CommandButtons\\BTNIronHordeSummoningCircle.blp");
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n08T))));
      this.AddQuestItem(QuestItemExpire.create(1227));
      this.AddQuestItem(QuestItemSelfExists.create());
      ;;
    }


}
