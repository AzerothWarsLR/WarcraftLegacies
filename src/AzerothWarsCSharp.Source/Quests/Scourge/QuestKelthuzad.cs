using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Scourge
{
  public sealed class QuestKelthuzad : QuestData{


    protected override string CompletionPopup => 
      string completionPopup = "KelFourCC(thuzad has been reanimated && empowered through the unlimited magical energies of the Sunwell.";
      if (FACTION_LEGION != 0){
        completionPopup = completionPopup + " He now has the ability to summon the Burning Legion.";
      }
      return completionPopup;
    }

    protected override string CompletionDescription => 
      return "KelFourCC(thuzad becomes a Lich";
    }

    protected override void OnComplete(){
      LEGEND_KELTHUZAD.UnitType = UNITTYPE_KELTHUZAD_LICH;
      LEGEND_KELTHUZAD.PermaDies = false;
      SetUnitState(LEGEND_KELTHUZAD.Unit, UNIT_STATE_LIFE, GetUnitState(LEGEND_KELTHUZAD.Unit, UNIT_STATE_MAX_LIFE));
      SetUnitState(LEGEND_KELTHUZAD.Unit, UNIT_STATE_MANA, GetUnitState(LEGEND_KELTHUZAD.Unit, UNIT_STATE_MAX_MANA));
      DestroyEffect(AddSpecialEffect("war3mapImported\\Soul Beam Blue.mdx", GetUnitX(LEGEND_KELTHUZAD.Unit), GetUnitY(LEGEND_KELTHUZAD.Unit)));
      DestroyEffect(AddSpecialEffect("Abilities\\Spells\\Undead\\FrostNova\\FrostNovaTarget.mdl", GetUnitX(LEGEND_KELTHUZAD.Unit), GetUnitY(LEGEND_KELTHUZAD.Unit)));
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Life Beyond Death", "KelFourCC("thuzad is the leader of the Cult of the Damned && an extraordinarily powerful necromancer. If he were to be brought to the Sunwell && submerged in its waters, he would be reanimated as an immortal Lich.", "ReplaceableTextures\\CommandButtons\\BTNLichVersion2blp"");
      this.AddQuestItem(new QuestItemControlLegend(LEGEND_SUNWELL, false));
      this.AddQuestItem(new QuestItemLegendInRect(LEGEND_KELTHUZAD, gg_rct_Sunwell, "The Sunwell"));
      ;;
    }


  }
}
