using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Scarlet
{
  public class QuestArgentDawn{

  
    private const int RESEARCH_ID = FourCC(R088)         ;//This research is required to complete the quest
    private const int QUEST_RESEARCH_ID = FourCC(R087)   ;//This research is given when the quest is completed
  



    bool operator Global( ){
      return true;
    }

    protected override string CompletionPopup => 
      return "The Argent Dawn has been declared && ready to join the " + this.Holder.Team.Name + ".";
    }

    protected override string CompletionDescription => 
      return "Unlock your elites, Crusader units && Tirion Fordring";
    }

    protected override void OnComplete(){
      this.Holder.Name = "Argent";
      this.Holder.Icon = "ReplaceableTextures\\CommandButtons\\BTNTirionPaladin.blp";
      SetPlayerTechResearched(FACTION_SCARLET.Player, FourCC(R086), 1);
      PlayThematicMusicBJ( "war3mapImported\\ScarletTheme.mp3" );
      SetPlayerColor(this.Holder.Player, PLAYER_COLOR_SNOW );

      FACTION_SCARLET.ModObjectLimit(FourCC(h08I), -UNLIMITED)           ;//Crusader
      FACTION_SCARLET.ModObjectLimit(FourCC(h09I), UNLIMITED)                 ;//Argent Crusader

      FACTION_SCARLET.ModObjectLimit(FourCC(h08L), -UNLIMITED)           ;//Cavalier
      FACTION_SCARLET.ModObjectLimit(FourCC(h0A3), UNLIMITED)                 ;//Lilian

      FACTION_SCARLET.ModObjectLimit(FourCC(h08J), -UNLIMITED)           ;//Arbalest
      FACTION_SCARLET.ModObjectLimit(FourCC(h09J), UNLIMITED)                 ;//Lilian
    }

    private void OnAdd( ){
      this.Holder.ModObjectLimit(RESEARCH_ID, 1);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Argent Dawn", "The Militia of Lordaeron has been solidified into the Argent Dawn, a strong military force lead by Tirion Fording.", "ReplaceableTextures\\CommandButtons\\BTNResurrection.blp");
      this.AddQuestItem(QuestItemResearch.create(RESEARCH_ID, FourCC(h00T)));
      this.AddQuestItem(QuestItemSelfExists.create());
      this.ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


  }
}
