using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup.FactionSetup;

namespace AzerothWarsCSharp.Source.Quests.Scourge
{
  public sealed class QuestKelthuzad : QuestData{
    
    protected override string CompletionPopup {
      get
      {
        string completionPopup = "KelFourCC(thuzad has been reanimated && empowered through the unlimited magical energies of the Sunwell.";
        if (LegionSetup.FACTION_LEGION != null){
          completionPopup += " He now has the ability to summon the Burning Legion.";
        }
        return completionPopup;
      }
    }

    protected override string CompletionDescription => "KelFourCC(thuzad becomes a Lich";

    protected override void OnComplete(){
      LEGEND_KELTHUZAD.UnitType = UNITTYPE_KELTHUZAD_LICH;
      LEGEND_KELTHUZAD.PermaDies = false;
      SetUnitState(LEGEND_KELTHUZAD.Unit, UNIT_STATE_LIFE, GetUnitState(LEGEND_KELTHUZAD.Unit, UNIT_STATE_MAX_LIFE));
      SetUnitState(LEGEND_KELTHUZAD.Unit, UNIT_STATE_MANA, GetUnitState(LEGEND_KELTHUZAD.Unit, UNIT_STATE_MAX_MANA));
      DestroyEffect(AddSpecialEffect("war3mapImported\\Soul Beam Blue.mdx", GetUnitX(LEGEND_KELTHUZAD.Unit), GetUnitY(LEGEND_KELTHUZAD.Unit)));
      DestroyEffect(AddSpecialEffect("Abilities\\Spells\\Undead\\FrostNova\\FrostNovaTarget.mdl", GetUnitX(LEGEND_KELTHUZAD.Unit), GetUnitY(LEGEND_KELTHUZAD.Unit)));
    }

    public  QuestKelthuzad ( ){
      thistype this = thistype.allocate("Life Beyond Death", "KelFourCC("thuzad is the leader of the Cult of the Damned && an extraordinarily powerful necromancer. If he were to be brought to the Sunwell && submerged in its waters, he would be reanimated as an immortal Lich.", "ReplaceableTextures\\CommandButtons\\BTNLichVersion2blp"");
      this.AddQuestItem(new QuestItemControlLegend(LEGEND_SUNWELL, false));
      this.AddQuestItem(new QuestItemLegendInRect(LEGEND_KELTHUZAD, Regions.Sunwell.Rect, "The Sunwell"));
      ;;
    }


  }
}
