using System.Collections.Generic;
using MacroTools.Spells;
using MacroTools.UnitTraits;
using WarcraftLegacies.Source.Shared.Spells;
using WarcraftLegacies.Source.Shared.UnitTraits.Vengeance;

namespace WarcraftLegacies.Source.Shared;

public static class SharedSpellSetup
{
  public static void Setup()
  {
    var massEnrage = new MassAnySpell(ABILITY_A0QK_MASS_ENRAGE_HAKKAR)
    {
      DummyAbilityId = ABILITY_ACUF_UNHOLY_FRENZY_DUMMY,
      DummyAbilityOrderId = ORDER_UNHOLY_FRENZY,
      Radius = 200,
      CastFilter = CastFilters.IsTargetEnemyAndAlive,
      TargetType = SpellTargetType.Point
    };
    SpellRegistry.Register(massEnrage);

    var seismicShard = new MassAnySpell(ABILITY_A0OD_SEISMIC_SHARD_AZIL)
    {
      DummyAbilityId = ABILITY_A0OE_SEISMIC_SHARD_AZIL_DUMMY,
      DummyAbilityOrderId = ORDER_THUNDERBOLT,
      Radius = 250,
      CastFilter = CastFilters.IsTargetEnemyAndAlive,
      TargetType = SpellTargetType.Point
    };
    SpellRegistry.Register(seismicShard);

    UnitTypeTraitRegistry.Register(new VengeanceTrait(ABILITY_A0OO_BURNING_VENGEANCE_TWILIGHT)
    {
      AlternateFormId = UNIT_E01A_BURNING_VENGEANCE_CREEP,
      HitsReviveThreshold = 5,
      HealBase = 900,
      HealLevel = 300,
      BonusDamageBase = 20,
      BonusDamageLevel = 20,
      Duration = 20,
      ReviveEffect = "Heal Blue.mdx"
    }, UNIT_O04H_CHAMPION_OF_THE_TWILIGHT_S_HAMMER_CREEP);

    var demonSoulCooldown = new CooldownReset(ABILITY_A0HF_ABILITY_COOLDOWN_RESET);
    SpellRegistry.Register(demonSoulCooldown);

    SpellRegistry.Register(new TomeOfRetrainingEx(ABILITY_ARET_TOME_OF_RETRAINING)
    {
      UnrefundableAbilityTypeIds = new List<int>
      {
        ABILITY_ZBPA_METAMORPHOSIS_PERMANENT_ILLIDAN
      }
    });
    SpellRegistry.Register(new MakeCasterVulnerable(ABILITY_A00M_SCROLL_TELE));
    SpellRegistry.Register(new MakeCasterVulnerable(ABILITY_A0CS_VASSAL_SCROLL_TELE));
    SpellRegistry.Register(new MakeCasterVulnerable(ABILITY_A002_SCROLL_TELE_TOWN));
    SpellRegistry.Register(new InstantKill(ABILITY_A126_SELF_DESTRUCT_SHARED)
    {
      Target = InstantKill.KillTarget.Self
    });
    SpellRegistry.Register(new InstantKill(ABILITY_A041_SELF_DESTRUCT_WORKERS)
    {
      Target = InstantKill.KillTarget.Self
    });
  }
}
