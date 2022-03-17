using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Scourge
{
  public class QuestKelthuzad{


    private string operator CompletionPopup( ){
      string completionPopup = "KelFourCC(thuzad has been reanimated && empowered through the unlimited magical energies of the Sunwell.";
      if (FACTION_LEGION != 0){
        completionPopup = completionPopup + " He now has the ability to summon the Burning Legion.";
      }
      return completionPopup;
    }

    private string operator CompletionDescription( ){
      return "KelFourCC(thuzad becomes a Lich";
    }

    private void OnComplete( ){
      LEGEND_KELTHUZAD.UnitType = UNITTYPE_KELTHUZAD_LICH;
      LEGEND_KELTHUZAD.PermaDies = false;
      SetUnitState(LEGEND_KELTHUZAD.Unit, UNIT_STATE_LIFE, GetUnitState(LEGEND_KELTHUZAD.Unit, UNIT_STATE_MAX_LIFE));
      SetUnitState(LEGEND_KELTHUZAD.Unit, UNIT_STATE_MANA, GetUnitState(LEGEND_KELTHUZAD.Unit, UNIT_STATE_MAX_MANA));
      DestroyEffect(AddSpecialEffect("war3mapImported\\Soul Beam Blue.mdx", GetUnitX(LEGEND_KELTHUZAD.Unit), GetUnitY(LEGEND_KELTHUZAD.Unit)));
      DestroyEffect(AddSpecialEffect("Abilities\\Spells\\Undead\\FrostNova\\FrostNovaTarget.mdl", GetUnitX(LEGEND_KELTHUZAD.Unit), GetUnitY(LEGEND_KELTHUZAD.Unit)));
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Life Beyond Death", "KelFourCC(thuzad is the leader of the Cult of the Damned && an extraordinarily powerful necromancer. If he were to be brought to the Sunwell && submerged in its waters, he would be reanimated as an immortal Lich.", "ReplaceableTextures\\CommandButtons\\BTNLichVersion2blp");
      this.AddQuestItem(QuestItemControlLegend.create(LEGEND_SUNWELL, false));
      this.AddQuestItem(QuestItemLegendInRect.create(LEGEND_KELTHUZAD, gg_rct_Sunwell, "The Sunwell"));
      ;;
    }


  }
}
