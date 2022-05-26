using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using AzerothWarsCSharp.Source.Setup.Legends;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Scourge
{
  public sealed class QuestKelthuzad : QuestData
  {
    public QuestKelthuzad() : base("Life Beyond Death",
      "Kel'thuzad is the leader of the Cult of the Damned and an extraordinarily powerful necromancer. If he were to be brought to the Sunwell and submerged in its waters, he would be reanimated as an immortal Lich.",
      "ReplaceableTextures\\CommandButtons\\BTNLichVersion2.blp")
    {
      AddObjective(new ObjectiveControlLegend(LegendQuelthalas.LegendSunwell, false));
      AddObjective(new ObjectiveLegendInRect(LegendScourge.LegendKelthuzad, Regions.Sunwell, "The Sunwell"));
      Required = true;
    }

    protected override string CompletionPopup
    {
      get
      {
        string completionPopup =
          "Kel'thuzad has been reanimated and empowered through the unlimited magical energies of the Sunwell.";
        if (LegionSetup.FactionLegion != null)
          completionPopup += " He now has the ability to summon the Burning Legion.";
        return completionPopup;
      }
    }

    protected override string RewardDescription => "Kel'thuzad becomes a Lich";

    protected override void OnComplete(Faction completingFaction)
    {
      LegendScourge.LegendKelthuzad.UnitType = LegendScourge.UnittypeKelthuzadLich;
      LegendScourge.LegendKelthuzad.PermaDies = false;
      SetUnitState(LegendScourge.LegendKelthuzad.Unit, UNIT_STATE_LIFE,
        GetUnitState(LegendScourge.LegendKelthuzad.Unit, UNIT_STATE_MAX_LIFE));
      SetUnitState(LegendScourge.LegendKelthuzad.Unit, UNIT_STATE_MANA,
        GetUnitState(LegendScourge.LegendKelthuzad.Unit, UNIT_STATE_MAX_MANA));
      DestroyEffect(AddSpecialEffect("war3mapImported\\Soul Beam Blue.mdx",
        GetUnitX(LegendScourge.LegendKelthuzad.Unit),
        GetUnitY(LegendScourge.LegendKelthuzad.Unit)));
      DestroyEffect(AddSpecialEffect("Abilities\\Spells\\Undead\\FrostNova\\FrostNovaTarget.mdl",
        GetUnitX(LegendScourge.LegendKelthuzad.Unit), GetUnitY(LegendScourge.LegendKelthuzad.Unit)));
    }
  }
}