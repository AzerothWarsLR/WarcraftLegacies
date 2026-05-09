using MacroTools.UnitTraits;
using WarcraftLegacies.Source.Shared.UnitTraits;

namespace WarcraftLegacies.Source.Factions.Ironforge;

public static class IronforgeTraits
{
  public static void Setup()
  {
    UnitTypeTraitRegistry.Register(new SpellOnAttack(ABILITY_A10J_MASTER_OF_LIGHTNING_STORMRIDERS)
    {
      DummyAbilityId = ABILITY_ACFL_FORKED_LIGHTNING_LIGHT_BLUE_HIGHBORNE,
      DummyOrderId = ORDER_FORKED_LIGHTNING,
      ProcChance = 0.2f
    }, UNIT_H03Z_STORMRIDER_IRONFORGE);

    UnitTypeTraitRegistry.Register(new SpellOnAttack(ABILITY_VP26_MASTER_OF_LIGHTNING_IRONFORGE_FALSTAD)
    {
      DummyAbilityId = ABILITY_VP27_FORKED_LIGHTNING_IRONFORGE_FALSTAD_DUMMY,
      DummyOrderId = ORDER_FORKED_LIGHTNING,
      ProcChance = 0.1f,
      ProcChancePerLevel = 0.1f,
    }, UNIT_H028_THANE_OF_AERIE_PEAK_IRONFORGE);
  }
}
