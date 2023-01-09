using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Scourge
{
  public sealed class QuestKelthuzadLich : QuestData
  {
    private static readonly int UnittypeKelthuzadLich = FourCC("Uktl");
    
    public QuestKelthuzadLich() : base("Into the Realm Eternal",
      "Kel'thuzad is the leader of the Cult of the Damned and an extraordinarily powerful necromancer. If he were to be brought to the Sunwell and submerged in its waters, he would be reanimated as an immortal Lich.",
      "ReplaceableTextures\\CommandButtons\\BTNLichVersion2.blp")
    {
      AddObjective(new ObjectiveControlCapital(LegendQuelthalas.LegendSunwell, false));
      AddObjective(new ObjectiveLegendInRect(LegendScourge.Kelthuzad, Regions.Sunwell, "The Sunwell"));
      Required = true;
    }

    /// <inheritdoc />
    protected override string CompletionPopup
    {
      get
      {
        var completionPopup =
          "Kel'thuzad has been reanimated and empowered through the unlimited magical energies of the Sunwell.";
        if (LegionSetup.Legion != null)
          completionPopup += " He now has the ability to summon the Burning Legion.";
        return completionPopup;
      }
    }

    /// <inheritdoc />
    protected override string RewardDescription => "Kel'thuzad becomes a Lich";

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      LegendScourge.Kelthuzad.UnitType = UnittypeKelthuzadLich;
      LegendScourge.Kelthuzad.PermaDies = false;
      SetUnitState(LegendScourge.Kelthuzad.Unit, UNIT_STATE_LIFE,
        GetUnitState(LegendScourge.Kelthuzad.Unit, UNIT_STATE_MAX_LIFE));
      SetUnitState(LegendScourge.Kelthuzad.Unit, UNIT_STATE_MANA,
        GetUnitState(LegendScourge.Kelthuzad.Unit, UNIT_STATE_MAX_MANA));
      DestroyEffect(AddSpecialEffect("war3mapImported\\Soul Beam Blue.mdx",
        GetUnitX(LegendScourge.Kelthuzad.Unit),
        GetUnitY(LegendScourge.Kelthuzad.Unit)));
      DestroyEffect(AddSpecialEffect("Abilities\\Spells\\Undead\\FrostNova\\FrostNovaTarget.mdl",
        GetUnitX(LegendScourge.Kelthuzad.Unit), GetUnitY(LegendScourge.Kelthuzad.Unit)));
    }
  }
}