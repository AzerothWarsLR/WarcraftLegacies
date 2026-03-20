using MacroTools.UnitTraits;
using WarcraftLegacies.Source.UnitTypeTraits;

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
  }
}
