using MacroTools.Spells;
using MacroTools.UnitTraits;
using WarcraftLegacies.Source.Setup.Spells;
using WarcraftLegacies.Source.Spells;
using WarcraftLegacies.Source.UnitTypeTraits.Vengeance;

namespace WarcraftLegacies.Source.Setup;

public static class SpellsSetup
{
  public static void Setup()
  {

    var thunderClap = new Stomp(ABILITY_A0QC_THUNDER_CLAP_FEL_HORDE_SHATTERED_HAND_EXECUTIONER)
    {
      Radius = 300,
      DamageBase = 75,
      DurationBase = 1,
      StunAbilityId = ABILITY_S00H_THUNDER_CLAP_DUMMY,
      StunOrderId = ORDER_CRIPPLE,
      SpecialEffect = @"Abilities\Spells\Human\Thunderclap\ThunderClapCaster.mdl"
    };
    SpellRegistry.Register(thunderClap);

    var thunderClapGil = new Stomp(ABILITY_MD13_THUNDER_CLAP_GILNEAS_GREY_GUARD)
    {
      Radius = 300,
      DamageBase = 55,
      DurationBase = 1,
      StunAbilityId = ABILITY_MD14_THUNDER_CLAP_DUMMY_GREY_GUARD,
      StunOrderId = ORDER_CRIPPLE,
      SpecialEffect = @"Abilities\Spells\Human\Thunderclap\ThunderClapCaster.mdl"
    };
    SpellRegistry.Register(thunderClapGil);

    var massAntiMagicShell = new MassAnySpell(ABILITY_A099_MASS_ANTI_MAGIC_SHIELD)
    {
      DummyAbilityId = ABILITY_A0JN_ANTI_MAGIC_SHELL_WARSONG_DUMMY,
      DummyAbilityOrderId = ORDER_ANTI_MAGIC_SHELL,
      Radius = 200,
      CastFilter = CastFilters.IsTargetAllyAndAlive,
      TargetType = SpellTargetType.Point
    };
    SpellRegistry.Register(massAntiMagicShell);

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

    FrostwolfSpellSetup.Setup();
    LegionSpellSetup.Setup();
    ScourgeSpellSetup.Setup();
    LordaeronSpellSetup.Setup();
    DruidsSpellSetup.Setup();
    QuelthalasSpellSetup.Setup();
    KulTirasSpellSetup.Setup();
    StormwindSpellSetup.Setup();
    IllidariSpellSetup.Setup();
    FelHordeSpellSetup.Setup();
    DraeneiSpellSetup.Setup();
    WarsongSpellSetup.Setup();
    IronforgeSpellSetup.Setup();
    SentinelSpellSetup.Setup();
    ScarletSpellSetup.Setup();
    DalaranSpellSetup.Setup();
    GilneasSpellSetup.Setup();
    SharedSpellSetup.Setup();
  }
}
