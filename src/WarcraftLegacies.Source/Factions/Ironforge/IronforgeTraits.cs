using MacroTools.Spells;
using MacroTools.UnitTraits;
using WarcraftLegacies.Source.Factions.Ironforge.UnitTraits;
using WarcraftLegacies.Source.Factions.Ironforge.UnitTraits.SecondWind;
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
    }, UNIT_HGRY_GRYPHON_RIDER_IRONFORGE);

    UnitTypeTraitRegistry.Register(new SpellOnAttackConeCast(ABILITY_TP27_FLAMETHROWER_FLAME_TANK)
    {
      DummyAbilityId = ABILITY_TP25_FLAMETHROWER_FLAME_TANK_DUMMY,
      DummyOrderId = ORDER_BREATH_OF_FIRE,
      ProcChance = 1.0f,
      Cooldown = 0,
      CastDistance = 250
    }, UNIT_TP01_FLAME_TANK_IRONFORGE);
    UnitTypeTraitRegistry.Register(new SpellOnAttack(ABILITY_VP26_MASTER_OF_LIGHTNING_IRONFORGE_FALSTAD)
    {
      DummyAbilityId = ABILITY_VP27_FORKED_LIGHTNING_IRONFORGE_FALSTAD_DUMMY,
      DummyOrderId = ORDER_FORKED_LIGHTNING,
      ProcChance = 0.1f,
      ProcChancePerLevel = 0.1f,
    }, UNIT_H028_THANE_OF_AERIE_PEAK_IRONFORGE);

    UnitTypeTraitRegistry.Register(
      new SecondWindTrait(ABILITY_TP46_SECOND_WIND_MURADIN)
      {
        HealPercentPerSecond = new LeveledAbilityField<float>
        {
          Base = 0f,
          PerLevel = 2f
        }
      },
      UNIT_HMBR_HIGH_THANE_OF_THE_BRONZEBEARDS_IRONFORGE
    );

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
