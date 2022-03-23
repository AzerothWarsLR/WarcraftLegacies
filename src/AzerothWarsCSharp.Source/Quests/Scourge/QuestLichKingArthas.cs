using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Scourge
{
  public class QuestLichKingArthas{


    bool operator Global( ){
      return true;
    }

    protected override string CompletionPopup => 
      return "Arthas has ascended the Frozen Throne itself && shattered NerFourCC("zhul")s frozen prison. Ner)zhul && Arthas are now joined, body && soul, into one being: the god-like Lich King.";
    }

    protected override string CompletionDescription => 
      return "Arthas becomes the Lich King, but the Frozen Throne loses its abilities";
    }

    protected override void OnComplete(){
      PlayThematicMusicBJ( "Sound\\Music\\mp3Music\\LichKingTheme.mp3" );
      LEGEND_LICHKING.DeathMessage = "Icecrown Citadel been razed. Unfortunately, the Lich King has already vacated his unholy throne.";
      LEGEND_LICHKING.PermaDies = false;
      LEGEND_LICHKING.Hivemind = false;
      UnitRemoveAbility(LEGEND_LICHKING.Unit, FourCC("A0W8"));
      UnitRemoveAbility(LEGEND_LICHKING.Unit, FourCC("A0L3"));
      UnitRemoveAbility(LEGEND_LICHKING.Unit, FourCC("A002"));
      UnitRemoveAbility(LEGEND_LICHKING.Unit, FourCC("A001"));
      BlzSetUnitMaxMana(LEGEND_LICHKING.Unit, 0);
      BlzSetUnitName(LEGEND_LICHKING.Unit, "Icecrown Citadel");
      LEGEND_ARTHAS.UnitType = FourCC("N023");
      LEGEND_ARTHAS.PermaDies = true;
      LEGEND_ARTHAS.Hivemind = true;
      LEGEND_ARTHAS.DeathMessage = "The great Lich King has been destroyed. With no central mind to command them, the forces of the Undead have gone rogue.";
      SetUnitState(LEGEND_ARTHAS.Unit, UNIT_STATE_LIFE, GetUnitState(LEGEND_ARTHAS.Unit, UNIT_STATE_MAX_LIFE));
      SetUnitState(LEGEND_ARTHAS.Unit, UNIT_STATE_MANA, GetUnitState(LEGEND_ARTHAS.Unit, UNIT_STATE_MAX_MANA));
      GeneralHelpers.UnitAddItemSafe(LEGEND_ARTHAS.Unit, ARTIFACT_HELMOFDOMINATION.item);
      this.Holder.Team = TEAM_SCOURGE;
      GeneralHelpers.UnitRescue(gg_unit_h00O_2516, FACTION_SCOURGE.Player);
      SetPlayerStateBJ( this.Holder.Player, PLAYER_STATE_FOOD_CAP_CEILING, 300 );
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Ascension", "From within the depths of the Frozen Throne, the Lich King NerFourCC("zhul cries out for his champion. Release the Helm of Domination from its confines && merge its power with that of the Scourge")s greatest Death Knight.", "ReplaceableTextures\\CommandButtons\\BTNRevenant.blp");
      this.AddQuestItem(QuestItemControlLegend.create(LEGEND_ARTHAS, false));
      this.AddQuestItem(QuestItemLegendLevel.create(LEGEND_ARTHAS, 12));
      this.AddQuestItem(QuestItemResearch.create(FourCC("R07X"), )u000)));
      this.AddQuestItem(QuestItemLegendInRect.create(LEGEND_ARTHAS, gg_rct_LichKing, "Icecrown Citadel"));
      ;;
    }


  }
}
