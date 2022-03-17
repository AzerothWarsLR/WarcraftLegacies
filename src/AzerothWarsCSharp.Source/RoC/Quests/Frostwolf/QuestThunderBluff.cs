//If the Centaur Khan dies, OR a time elapses, give Thunder Bluff to a Horde player.
public class QuestThunderBluff{

  
    private group ThunderBluffUnits;
    private const int QUEST_RESEARCH_ID = FourCC(R05I);
  



    private string operator CompletionPopup( ){

    }

    private string operator CompletionDescription( ){
      return "Control of Thunder Bluff";
    }

    private void OnFail( ){
        RescueNeutralUnitsInRect(gg_rct_ThunderBluff, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    private void OnComplete( ){
      RescueNeutralUnitsInRect(gg_rct_ThunderBluff, this.Holder.Player);
      if (GetLocalPlayer() == this.Holder.Player){
        PlayThematicMusicBJ( "war3mapImported\\TaurenTheme.mp3" );
      }
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Long March", "The Tauren have been wandering for too long. The plains of Mulgore would offer respite from this endless journey.", "ReplaceableTextures\\CommandButtons\\BTNCentaurKhan.blp");
      this.AddQuestItem(QuestItemLegendDead.create(LEGEND_CENTAURKHAN));
      this.AddQuestItem(QuestItemAnyUnitInRect.create(gg_rct_ThunderBluff, "Thunder Bluff", true));
      this.AddQuestItem(QuestItemExpire.create(1455));
      this.AddQuestItem(QuestItemSelfExists.create());
      this.ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


  private static void OnInit( ){
    //Setup initially invulnerable and hidden group at Thunder Bluff
    group tempGroup = CreateGroup();
    unit u;
    int i = 0;
    ThunderBluffUnits = CreateGroup();
    GroupEnumUnitsInRect(tempGroup, gg_rct_ThunderBluff, null);
    while(true){
      u = FirstOfGroup(tempGroup);
      if ( u == null){ break; }
      if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)){
        SetUnitInvulnerable(u, true);
        GroupAddUnit(ThunderBluffUnits, u);
      }
      GroupRemoveUnit(tempGroup, u);
      i = i + 1;
    }
    DestroyGroup(tempGroup);
    tempGroup = null;

  }

}
