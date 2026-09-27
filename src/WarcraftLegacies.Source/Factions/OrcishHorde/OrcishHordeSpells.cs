using MacroTools.Spells;
using WarcraftLegacies.Source.Factions.OrcishHorde.Spells.ElementalConvergence;

namespace WarcraftLegacies.Source.Factions.OrcishHorde;

public static class OrcishHordeSpells
{
  public static void Setup()
  {
    var elementalConvergence = new ElementalConvergenceSpell(ABILITY_OTCA_ELEMENTAL_CONVERGENCE_THRALL)
    {
      ChannelDuration = 2f,
      DamageByLevel = new float[] { 175, 250, 350, 450 },
      Radius = 225,
      MissileSpeed = 900,
      StunAbilityId = ABILITY_OTCB_ELEMENTAL_CONVERGENCE_STUN_APPLICATOR_THRALL
    };
    SpellRegistry.Register(elementalConvergence);
  }
}
