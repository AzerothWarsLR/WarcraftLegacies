public class QuestConquerKul{

  
    private const int QUEST_RESEARCH_ID = FourCC(R08D)   ;//This research is given when the quest is completed
  


    private string operator CompletionPopup( ){
      return "Before setting sails we need to conquer KulFourCC(tiras";
    }

    private string operator CompletionDescription( ){
      return "Unlock shipyards";
    }

    private string operator FailurePopup( ){
      return "Zandalar has fallen";
    }

    private string operator FailureDescription( ){
      return "You can no longer build shipyards, but you unlock Zulfarrak";
    }

    private void OnFail( ){
      unit u;
      group tempGroup;
      tempGroup = CreateGroup();
      GroupEnumUnitsInRect(tempGroup, gg_rct_Zulfarrak, null);
      u = FirstOfGroup(tempGroup);
      while(true){
      if ( u == null){ break; }
        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE) || GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_AGGRESSIVE)){
          if (IsUnitType(u, UNIT_TYPE_HERO) == true){
            KillUnit(u);
          }else {
            UnitRescue(u, this.Holder.Player);
          }
        }
        GroupRemoveUnit(tempGroup, u);
        u = FirstOfGroup(tempGroup);
      }
      DestroyGroup(tempGroup);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Conquer Boralus", "The KulFourCC(tiran people && their fleet have been a threat to the Zandalari Empire for ages, it is time to put them to rest. ", "ReplaceableTextures\\CommandButtons\\BTNGalleonIcon.blp");
      this.AddQuestItem(QuestItemControlLegend.create(LEGEND_DAZARALOR, true));
      this.AddQuestItem(QuestItemLegendDead.create(LEGEND_BORALUS));
      this.ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


}
