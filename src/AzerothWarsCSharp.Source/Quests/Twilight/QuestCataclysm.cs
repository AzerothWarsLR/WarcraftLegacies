using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Twilight
{
  public sealed class QuestCataclysm : QuestData{

  
    private const int CATACLYSM_RESEARCH = FourCC("R05E");
  



    bool operator Global( ){
      return true;
    }

    protected override string CompletionPopup => 
      return "Deathwing is here, Doomsday is at hand, the Cataclysm as begun!";
    }

    protected override string CompletionDescription => 
      return "Cultists all over the world join your cause actively, Deathwing as a super demihero && the 2 elemental ascendant heroes.";
    }

    protected override void OnComplete(){
      SetPlayerTechResearched(this.Holder.Player, CATACLYSM_RESEARCH, 1);
      PlayThematicMusicBJ( "war3mapImported\\TwilightTheme.mp3" );
      SetPlayerTechResearched(FACTION_CTHUN.Player, FourCC("R07D"), 1);
      IssueImmediateOrderBJ( gg_unit_h02U_2413, "unrobogoblin" );
    }

    private void OnAdd( ){
      this.Holder.ModObjectLimit(CATACLYSM_RESEARCH, UNLIMITED);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Cataclysm", "The Old GodFourCC("s will is finnicky, you are !privy to when their plan will be in motion, but when it is, your cult will be ready to welcome it.", "ReplaceableTextures\\CommandButtons\\BTNDeathwing.blp"");
      this.AddQuestItem(new QuestItemControlLegend(LEGEND_DEATHWING, false));
      ;;
    }


  }
}
