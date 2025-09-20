using MacroTools.PassiveAbilities;
using MacroTools.PassiveAbilitySystem;
using MacroTools.Spells;
using MacroTools.SpellSystem;
using WarcraftLegacies.Source.PassiveAbilities.Vengeance;
using WarcraftLegacies.Source.Setup.Spells;
using WarcraftLegacies.Source.Spells;

namespace WarcraftLegacies.Source.Setup
{
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
      SpellSystem.Register(thunderClap);

      var thunderClapGil = new Stomp(ABILITY_MD13_THUNDER_CLAP_GILNEAS_GREY_GUARD)
      {
        Radius = 300,
        DamageBase = 55,
        DurationBase = 1,
        StunAbilityId = ABILITY_MD14_THUNDER_CLAP_DUMMY_GREY_GUARD,
        StunOrderId = ORDER_CRIPPLE,
        SpecialEffect = @"Abilities\Spells\Human\Thunderclap\ThunderClapCaster.mdl"
      };
      SpellSystem.Register(thunderClapGil);

      var massAntiMagicShell = new MassAnySpell(FourCC("A099"))
      {
        DummyAbilityId = FourCC("A0JN"),
        DummyAbilityOrderId = ORDER_ANTI_MAGIC_SHELL,
        Radius = 200,
        CastFilter = CastFilters.IsTargetAllyAndAlive,
        TargetType = SpellTargetType.Point
      };
      SpellSystem.Register(massAntiMagicShell);

      var massEnrage = new MassAnySpell(FourCC("A0QK"))
      {
        DummyAbilityId = FourCC("ACuf"),
        DummyAbilityOrderId = ORDER_UNHOLY_FRENZY,
        Radius = 200,
        CastFilter = CastFilters.IsTargetEnemyAndAlive,
        TargetType = SpellTargetType.Point
      };
      SpellSystem.Register(massEnrage);


      var thunderFists = new SpellOnAttack(UNIT_O01P_LEADER_OF_THE_TWILIGHT_S_HAMMER_TWILIGHT_HAMMER,
        ABILITY_A0LN_THUNDER_FISTS_CHO_GALL)
      {
        DummyAbilityId = ABILITY_A024_THUNDER_FISTS_CHO_GALL_DUMMY_CAST,
        DummyOrderId = ORDER_FORKED_LIGHTNING,
        ProcChance = 0.15f
      };
      PassiveAbilityManager.Register(thunderFists);

      var seismicShard = new MassAnySpell(ABILITY_A0OD_SEISMIC_SHARD_AZIL)
      {
        DummyAbilityId = ABILITY_A0OE_SEISMIC_SHARD_AZIL_DUMMY,
        DummyAbilityOrderId = ORDER_THUNDERBOLT,
        Radius = 250,
        CastFilter = CastFilters.IsTargetEnemyAndAlive,
        TargetType = SpellTargetType.Point
      };
      SpellSystem.Register(seismicShard);


      var burningVengeance = new VengeanceAbility(FourCC("O04H"), FourCC("A0OO"))
      {
        AlternateFormId = FourCC("e01A"),
        HitsReviveThreshold = 5,
        HealBase = 900,
        HealLevel = 300,
        BonusDamageBase = 20,
        BonusDamageLevel = 20,
        Duration = 20,
        ReviveEffect = "Heal Blue.mdx"
      };
      PassiveAbilityManager.Register(burningVengeance);


      var demonSoulCooldown = new CooldownReset(ABILITY_A0HF_ABILITY_COOLDOWN_RESET);
      SpellSystem.Register(demonSoulCooldown);

      SpellSystem.Register(new MakeCasterVulnerable(ABILITY_A00M_SCROLL_TELE));
      SpellSystem.Register(new MakeCasterVulnerable(ABILITY_A0CS_VASSAL_SCROLL_TELE));
      SpellSystem.Register(new MakeCasterVulnerable(ABILITY_A002_SCROLL_TELE_TOWN));
      SpellSystem.Register(new InstantKill(ABILITY_A126_SELF_DESTRUCT_SHARED)
      {
        Target = InstantKill.KillTarget.Self
      });
      SpellSystem.Register(new InstantKill(ABILITY_A041_SELF_DESTRUCT_WORKERS)
      {
        Target = InstantKill.KillTarget.Self
      });

      FrostwolfSpellSetup.Setup();
      LegionSpellSetup.Setup();
      GoblinSpellSetup.Setup();
      ScourgeSpellSetup.Setup();
      LordaeronSpellSetup.Setup();
      DruidsSpellSetup.Setup();
      QuelthalasSpellSetup.Setup();
      KulTirasSpellSetup.Setup();
      StormwindSpellSetup.Setup();
      DragonmawSpellSetup.Setup();
      IllidariSpellSetup.Setup();
      FelHordeSpellSetup.Setup();
      DraeneiSpellSetup.Setup();
      WarsongSpellSetup.Setup();
      IronforgeSpellSetup.Setup();
      SentinelSpellSetup.Setup();
      ScarletSpellSetup.Setup();
      DalaranSpellSetup.Setup();
      TrollSpellSetup.Setup();
      GilneasSpellSetup.Setup();
      SharedSpellSetup.Setup();
    }
  }
}