public class QuestDarkIron{

  
    private const int HERO_ID = FourCC(H03G);
    private const int RESEARCH_ID = FourCC(R01A);
  


    private string operator CompletionPopup( ){
      return "The peace talk were succesful, The Dark Iron will join the Dwarven Empire.";
    }

    private string operator CompletionDescription( ){
      return "You gain control of Shadowforge City && can train the hero Dagran Thaurassian from the Altar of Fortitude";
    }

    private void OnComplete( ){
      group tempGroup = CreateGroup();
      unit u;
      //Transfer all Neutral Passive units in region to Ironforge
      GroupEnumUnitsInRect(tempGroup, gg_rct_Shadowforge_City, null);
      u = FirstOfGroup(tempGroup);
      while(true){
      if ( u == null){ break; }
        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)){
          UnitRescue(u, this.Holder.Player);
        }
        GroupRemoveUnit(tempGroup, u);
        u = FirstOfGroup(tempGroup);
      }
      DestroyGroup(tempGroup);
      tempGroup = null;
      SetPlayerTechResearched(this.Holder.Player, RESEARCH_ID, 1);
    }

    private void OnAdd( ){
      Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED);
      Holder.ModObjectLimit(HERO_ID, 1);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Dark Iron Alliance", "The Dark Iron dwarves are renegades. Bring Magni to their capital to open negotiations for an alliance.", "ReplaceableTextures\\CommandButtons\\BTNRPGDarkIron.blp");
      this.AddQuestItem(QuestItemLegendInRect.create(LEGEND_MAGNI, gg_rct_Shadowforge_gate, "Shadowforge"));
      ;;
    }


}
