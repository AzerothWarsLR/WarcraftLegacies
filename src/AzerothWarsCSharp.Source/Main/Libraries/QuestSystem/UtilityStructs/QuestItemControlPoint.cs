public class QuestItemControlPoint{


    private static trigger unitDies = CreateTrigger();
    private ControlPoint target = 0;
    private static int count = 0;
    private static thistype[] byIndex;

    float operator X( ){
      return GetUnitX(target.Unit);
    }

    float operator Y( ){
      return GetUnitY(target.Unit);
    }

    private void OnAdd( ){
      if (this.Holder.Team.ContainsPlayer(GetOwningPlayer(target.Unit))){
        this.Progress = QUEST_PROGRESS_COMPLETE;
      }
    }

    private void OnTargetChangeOwner( ){
      if (this.Holder.Team.ContainsPlayer(GetOwningPlayer(target.Unit))){
        this.Progress = QUEST_PROGRESS_COMPLETE;
      }else {
        this.Progress = QUEST_PROGRESS_INCOMPLETE;
      }
    }

    public static void OnFactionTeamJoin( ){
      int i = 0;
      thistype loopItem;
      Team loopItemHolderTeam;
      while(true){
        if ( i == thistype.count){ break; }
        //Iterate across all QuestItemControlPoints held by Factions in either the Team that was left or the Team that was joined
        loopItem = thistype.byIndex[i];
        loopItemHolderTeam = loopItem.Holder.Team;
        if (loopItemHolderTeam == GetTriggerFaction().Team || loopItemHolderTeam == GetTriggerFactionPrevTeam()){
          loopItem.OnTargetChangeOwner();
        }
        i = i + 1;
      }
    }

    public static void OnAnyControlPointChangeOwner( ){
      int i = 0;
      thistype loopItem;
      while(true){
        if ( i == thistype.count){ break; }
        loopItem = thistype.byIndex[i];
        if (loopItem.target == GetTriggerControlPoint()){
          loopItem.OnTargetChangeOwner();
        }
        i = i + 1;
      }
    }

     thistype (ControlPoint target ){

      this.target = target;
      this.Description = "Your team controls " + target.Name;
      this.targetWidget = target.Unit;
      thistype.byIndex[thistype.count] = this;
      thistype.count = thistype.count + 1;
      ;;
    }


  private static void OnInit( ){
    trigger trigOwnerChange = CreateTrigger();
    trigger trigFaction = CreateTrigger();
    OnControlPointOwnerChange.register(trigOwnerChange);
    OnFactionTeamJoin.register(trigFaction);
    TriggerAddAction(trigOwnerChange,  QuestItemControlPoint.OnAnyControlPointChangeOwner);
    TriggerAddAction(trigFaction,  QuestItemControlPoint.OnFactionTeamJoin);
  }

}
