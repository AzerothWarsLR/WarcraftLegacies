using MacroTools.UnitTraits;
using WarcraftLegacies.Source.Factions.Ironforge.UnitTraits;
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

    UnitTypeTraitRegistry.Register(
      new AvatarOfTheMountain(
        ABILITY_MD07_AVATAR_OF_THE_MOUNTAIN_MURADIN,
        30,
        1.00f,
        150
      ),
      UNIT_HMBR_HIGH_THANE_OF_THE_BRONZEBEARDS_IRONFORGE
    );

    UnitTypeTraitRegistry.Register(
      new TauntOnAvatarCast(
        ABILITY_MD07_AVATAR_OF_THE_MOUNTAIN_MURADIN,
        ORDER_TAUNT
      ),
      UNIT_HMBR_HIGH_THANE_OF_THE_BRONZEBEARDS_IRONFORGE
    );
  }
}
