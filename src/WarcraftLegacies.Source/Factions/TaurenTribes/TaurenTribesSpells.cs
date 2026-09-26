using System.Collections.Generic;
using MacroTools.Spells;
using WarcraftLegacies.Source.Factions.Frostwolf.Spells;
using WarcraftLegacies.Source.Factions.TaurenTribes.Spells;
using WarcraftLegacies.Source.Shared.Spells;

namespace WarcraftLegacies.Source.Factions.TaurenTribes;

public static class TaurenTribesSpells
{
  public static void Setup()
  {
    var devour = new Devour(ABILITY_ADEV_DEVOUR_KODO_BEAST)
    {
      PercentageOfMaxHealth = 0.5f
    };
    SpellRegistry.Register(devour);

    SpellRegistry.Register(new AncestralLegion(ABILITY_A0YX_ANCESTRAL_LEGION_FROSTWOLF_CAIRNE)
    {
      Duration = 60,
      HealthBonus = new LeveledAbilityField<float>
      {
        Base = 0.2f,
        PerLevel = 0.1f
      },
      DamageBonus = new LeveledAbilityField<float>
      {
        Base = 0.2f,
        PerLevel = 0.1f
      },
      SummonCap = new LeveledAbilityField<int>
      {
        Base = 6,
        PerLevel = 6
      },
      RememberChance = 1f,
      RememberableUnitTypeId = UNIT_OTAU_TAUREN_TAUREN_TRIBES,
      SummonEffect = @"Abilities\Spells\Demon\DarkPortal\DarkPortalTarget.mdl",
      DeathEffect = @"Abilities\Spells\Orc\Disenchant\DisenchantSpecialArt.mdl"
    });

    var warStompChieftainOgreLord = new MassAnySpell(ABILITY_AT06_WAR_STOMP_TAUREN_TRIBES)
    {
      Radius = 300,
      Damage = new LeveledAbilityField<float>
      {
        PerLevel = 25
      },
      DummyAbilityId = ABILITY_AT11_STUN_UNIT_TAUREN_TRIBES,
      DummyAbilityOrderId = ORDER_THUNDERBOLT,
      SpecialEffect = @"Abilities\Spells\Orc\WarStomp\WarStompCaster.mdl",
      CastFilter = CastFilters.IsTargetEnemyAliveAndGroundUnits,
      TargetType = SpellTargetType.None
    };
    SpellRegistry.Register(warStompChieftainOgreLord);

    SpellRegistry.Register(new ChallengingTaunt(ABILITY_A15C_CHALLENGING_TAUNT_TAUREN_TRIBES_OGRE_LORD)
    {
      ArmorAbilityId = ABILITY_A15D_CHALLENGING_TAUNT_ARMOR_TAUREN_TRIBES_OGRE_LORD_DUMMY
    });

    SpellRegistry.Register(new SpiritMend(ABILITY_A14Y_SPIRIT_MEND_TAUREN_TRIBES_MAGATHA)
    {
      Healing = new LeveledAbilityField<float>
      {
        Base = 25,
        PerLevel = 25
      },
      MaximumBounces = 3,
      HealingReductionPerBounce = 0.15f,
      BounceRadius = 500,
      ShieldAbilityId = ABILITY_A152_EARTHEN_SHIELD_TAUREN_TRIBES_MAGATHA_DUMMY
    });

    SpellRegistry.Register(new GrimtotemWard(ABILITY_A14Z_GRIMTOTEM_WARD_TAUREN_TRIBES_MAGATHA)
    {
      WardTypeId = UNIT_OTGW_GRIMTOTEM_WARD_TAUREN_TRIBES,
      Duration = 15,
      AuraAbilityIds = new List<int>
      {
        ABILITY_A154_GRIMTOTEM_WARD_HEALING_TAUREN_TRIBES_GRIMTOTEM_WARD,
        ABILITY_A155_GRIMTOTEM_WARD_SLOW_TAUREN_TRIBES_GRIMTOTEM_WARD
      }
    });

    SpellRegistry.Register(new CronesCurse(ABILITY_A150_CRONE_S_CURSE_TAUREN_TRIBES_MAGATHA)
    {
      Healing = new LeveledAbilityField<float>
      {
        Base = 25,
        PerLevel = 50
      },
      Radius = 500,
      Duration = 12,
      HeroDuration = 6
    });

    SpellRegistry.Register(new WrathOfTheEarthMother(ABILITY_A151_WRATH_OF_THE_EARTH_MOTHER_TAUREN_TRIBES_MAGATHA)
    {
      Amount = new LeveledAbilityField<float>
      {
        Base = 15,
        PerLevel = 15
      },
      Radius = 450,
      Duration = 8,
      Period = 1,
      RootAbilityId = ABILITY_A153_EARTH_MOTHER_S_ROOTS_TAUREN_TRIBES_MAGATHA_DUMMY,
      RootBuffId = BUFF_B0E2_EARTH_MOTHER_S_ROOTS
    });
  }
}
