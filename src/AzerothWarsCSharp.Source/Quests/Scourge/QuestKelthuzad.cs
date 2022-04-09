using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;
using AzerothWarsCSharp.Source.Setup.FactionSetup;

namespace AzerothWarsCSharp.Source.Quests.Scourge
{
  public sealed class QuestKelthuzad : QuestData
  {
    public QuestKelthuzad()
    {
      thistype this = thistype.allocate("Life Beyond Death",
        "KelFourCC("thuzad is the leader of the Cult of the Damned && an extraordinarily powerful necromancer
          .If he were to be brought to the Sunwell && submerged in its waters,
        he would be reanimated as an immortal Lich.", "ReplaceableTextures\\CommandButtons\\BTNLichVersion2blp");
      AddQuestItem(new QuestItemControlLegend(LegendQuelthalas.LegendSunwell, false));
      AddQuestItem(new QuestItemLegendInRect(LegendScourge.LegendKelthuzad, Regions.Sunwell.Rect, "The Sunwell"));
    }

    protected override string CompletionPopup
    {
      get
      {
        string completionPopup =
          "KelFourCC(thuzad has been reanimated && empowered through the unlimited magical energies of the Sunwell.";
        if (LegionSetup.FactionLegion != null)
          completionPopup += " He now has the ability to summon the Burning Legion.";
        return completionPopup;
      }
    }

    protected override string RewardDescription => "KelFourCC(thuzad becomes a Lich";

    protected override void OnComplete()
    {
      LegendScourge.LegendKelthuzad.UnitType = UNITTYPE_KELTHUZAD_LICH;
      LegendScourge.LegendKelthuzad.PermaDies = false;
      SetUnitState(LegendScourge.LegendKelthuzad.Unit, UNIT_STATE_LIFE, GetUnitState(LegendScourge.LegendKelthuzad.Unit, UNIT_STATE_MAX_LIFE));
      SetUnitState(LegendScourge.LegendKelthuzad.Unit, UNIT_STATE_MANA, GetUnitState(LegendScourge.LegendKelthuzad.Unit, UNIT_STATE_MAX_MANA));
      DestroyEffect(AddSpecialEffect("war3mapImported\\Soul Beam Blue.mdx", GetUnitX(LegendScourge.LegendKelthuzad.Unit),
        GetUnitY(LegendScourge.LegendKelthuzad.Unit)));
      DestroyEffect(AddSpecialEffect("Abilities\\Spells\\Undead\\FrostNova\\FrostNovaTarget.mdl",
        GetUnitX(LegendScourge.LegendKelthuzad.Unit), GetUnitY(LegendScourge.LegendKelthuzad.Unit)));
    }
  }
}