using MacroTools.Spells;
using WarcraftLegacies.Source.Factions.OrcishHorde.Spells.ElementalConvergence;

namespace WarcraftLegacies.Source.Factions.OrcishHorde;

public static class OrcishHordeSpells
{
  public static void Setup()
  {
    var elementalConvergence = new ElementalConvergenceSpell(ABILITY_A166_ELEMENTAL_CONVERGENCE_THRALL)
    {
      ChannelDuration = 2f,
      DamageByLevel = new float[] { 100, 175, 250, 325 },
      Radius = 225,
      MissileSpeed = 900,
      StunAbilityId = ABILITY_OTCB_ELEMENTAL_CONVERGENCE_STUN_THRALL_ELEMENTAL_CONVERGENCE_STUN_APPLICATOR
    };
    SpellRegistry.Register(elementalConvergence);
  }
}
