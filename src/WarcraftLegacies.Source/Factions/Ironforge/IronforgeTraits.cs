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

    UnitTypeTraitRegistry.Register(new SpellOnAttackPointCast(ABILITY_TP27_FLAMETHROWER_FLAME_TANK)
    {
      DummyAbilityId = ABILITY_TP26_FLAMETHROWER_FLAME_TANK_DUMMY,
      DummyOrderId = ORDER_BREATH_OF_FIRE,
      ProcChance = 1.0f,
      Cooldown = 0,
      CastDistance = 600
    }, UNIT_H01P_STEAM_TANK_IRONFORGE);
  }
}
