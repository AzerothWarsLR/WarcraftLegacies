using AzerothWarsCSharp.MacroTools.Spells;
using AzerothWarsCSharp.MacroTools.SpellSystem;
using AzerothWarsCSharp.MacroTools.UnitEffects;
using AzerothWarsCSharp.Source.Setup.Spells;
using AzerothWarsCSharp.Source.Spells;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup
{
  public static class SpellsSetup
  {
    public static void Setup()
    {
      var warStompImmoltar = new Stomp(Constants.ABILITY_A0LU_WAR_STOMP_IMMOLTAR)
      {
        Radius = 200,
        DamageBase = 9000,
        DurationBase = 3,
        StunAbilityId = FourCC("A0WN"),
        StunOrderString = "thunderbolt"
      };
      SpellSystem.Register(warStompImmoltar);

      var warStompKazzak = new Stomp(Constants.ABILITY_A0AW_WAR_STOMP_BLUE_DOOM_GUARD_TEAL_KAZZAK)
      {
        Radius = 300,
        DamageBase = 25,
        DurationBase = 3,
        StunAbilityId = FourCC("A0WN"),
        StunOrderString = "thunderbolt"
      };
      SpellSystem.Register(warStompKazzak);

      var thunderClap = new Stomp(FourCC("A0QC"))
      {
        Radius = 225,
        DamageBase = 65,
        DurationBase = 1,
        StunAbilityId = FourCC("S00H"),
        StunOrderString = "cripple"
      };
      SpellSystem.Register(thunderClap);

      var massAntiMagicShell = new MassAnySpell(FourCC("A099"))
      {
        DummyAbilityId = FourCC("A0JN"),
        DummyAbilityOrderString = "antimagicshell",
        Radius = 200,
        CastFilter = CastFilters.IsTargetAllyAndAlive,
        TargetType = SpellTargetType.Point
      };
      SpellSystem.Register(massAntiMagicShell);

      var massEnrage = new MassAnySpell(FourCC("A0QK"))
      {
        DummyAbilityId = FourCC("ACuf"),
        DummyAbilityOrderString = "unholyfrenzy",
        Radius = 200,
        CastFilter = CastFilters.IsTargetEnemyAndAlive,
        TargetType = SpellTargetType.Point
      };
      SpellSystem.Register(massEnrage);

      var massFrostArmor = new MassAnySpell(Constants.ABILITY_A0H3_MASS_ICE_ARMOR_WARSONG_GAHZ_RILLA)
      {
        DummyAbilityId = Constants.ABILITY_A0H6_MASS_ICE_ARMOR_WARSONG_GAHZ_RILLA_DUMMY,
        DummyAbilityOrderString = "frostarmor",
        Radius = 200,
        CastFilter = CastFilters.IsTargetAllyAndAlive,
        TargetType = SpellTargetType.Point
      };
      SpellSystem.Register(massFrostArmor);

      var scattershot = new MassAnySpell(Constants.ABILITY_A0GP_SCATTERSHOT_KUL_TIRAS_LADY_ASHVANE)
      {
        DummyAbilityId = Constants.ABILITY_A0GL_SCATTERSHOT_KUL_TIRAS_LADY_ASHVANE_DUMMY,
        DummyAbilityOrderString = "thunderbolt",
        Radius = 250,
        CastFilter = CastFilters.IsTargetEnemyAndAlive,
        TargetType = SpellTargetType.Point
      };
      SpellSystem.Register(scattershot);

      var massBanish = new MassAnySpell(Constants.ABILITY_A0FD_MASS_BANISH_QUEL_THALAS_KAEL_THAS)
      {
        DummyAbilityId = Constants.ABILITY_A0FE_MASS_BANISH_QUEL_THALAS_KAEL_THAS_DUMMY_CASTER,
        DummyAbilityOrderString = "banish",
        Radius = 250,
        CastFilter = CastFilters.IsTargetOrganicAndAlive,
        TargetType = SpellTargetType.Point
      };
      SpellSystem.Register(massBanish);

      var thunderFists = new SpellOnAttack(Constants.ABILITY_A0LN_THUNDER_FISTS_CHO_GALL)
      {
        DummyAbilityId = Constants.ABILITY_A024_THUNDER_FISTS_CHO_GALL_DUMMY_CAST,
        DummyOrderString = "forkedlightning",
        ProcChance = 0.15f
      };
      SpellSystem.Register(thunderFists);

      var seismicShard = new MassAnySpell(Constants.ABILITY_A0OD_SEISMIC_SHARD_AZIL)
      {
        DummyAbilityId = Constants.ABILITY_A0OE_SEISMIC_SHARD_AZIL_DUMMY,
        DummyAbilityOrderString = "thunderbolt",
        Radius = 250,
        CastFilter = CastFilters.IsTargetEnemyAndAlive,
        TargetType = SpellTargetType.Point
      };
      SpellSystem.Register(seismicShard);

      var elunesGaze = new MassAnySpell(Constants.ABILITY_A0VX_ELUNE_S_GAZE_SENTINELS)
      {
        DummyAbilityId = Constants.ABILITY_A0VY_INVISIBILITY_LB,
        DummyAbilityOrderString = "invisibility",
        Radius = 350,
        CastFilter = CastFilters.IsTargetOrganicAndAlive,
        TargetType = SpellTargetType.Point
      };
      SpellSystem.Register(elunesGaze);

      var massSimulacrum = new MassSimulacrum(Constants.ABILITY_A0DG_MASS_SIMULACRUM_ORANGE_ANTONIDAS)
      {
        Radius = 150,
        CountBase = 2,
        CountLevel = 4,
        Duration = 60,
        Effect = @"war3mapImported\Soul Discharge Blue.mdx",
        EffectScale = 1.1f,
        EffectTarget = @"Abilities\Spells\Items\AIil\AIilTarget.mdl",
        EffectScaleTarget = 1.0f,
        HealthBonusBase = -0.5f,
        HealthBonusLevel = 0.2f,
        DamageBonusBase = -0.5f,
        DamageBonusLevel = 0.2f
      };
      SpellSystem.Register(massSimulacrum);

      var bombingRun = new ChannelAnySpell(Constants.ABILITY_A0S1_BOMBING_RUN_DARK_GREEN)
      {
        DummyAbilityId = FourCC("A0S1"),
        DummyAbilityOrderString = "locustswarm"
      };
      SpellSystem.Register(bombingRun);

      var summonGraniteGolems = new SummonUnits(Constants.ABILITY_A0EP_SUMMON_GRANITE_GOLEMS_QUEL_THALAS_SUNWELL)
      {
        SummonUnitTypeId = FourCC("nggr"),
        SummonCount = 4,
        Duration = 60,
        Radius = 400,
        AngleOffset = 45,
        Effect = @"war3mapImported\Earth NovaTarget.mdx"
      };
      SpellSystem.Register(summonGraniteGolems);

      var resurgentFlameStrike = new ResurgentSpell(Constants.ABILITY_A04H_RESURGENT_FLAME_STRIKE_QUEL_THALAS_KAEL_THAS,
        Constants.ABILITY_A0F9_RESURGENT_FLAME_STRIKE_QUEL_THALAS_KAEL_THAS_DUMMY, "flamestrike")
      {
        Duration = 14,
        Interval = 7
      };
      SpellSystem.Register(resurgentFlameStrike);

      var executeWarsong = new Execute(Constants.UNIT_O021_RAVAGER_WARSONG);
      SpellSystem.Register(executeWarsong);

      var executeBlackEmpire = new Execute(FourCC("n0B4"));
      SpellSystem.Register(executeBlackEmpire);

      var maievVengeance = new Vengeance(FourCC("Ewrd"), FourCC("A017"))
      {
        AlternateFormId = FourCC("espv"),
        HitsReviveThreshold = 5,
        HealBase = 900,
        HealLevel = 300,
        BonusDamageBase = 20,
        BonusDamageLevel = 20,
        Duration = 20,
        ReviveEffect = "Heal Blue.mdx"
      };
      SpellSystem.Register(maievVengeance);

      var burningVengeance = new Vengeance(FourCC("O04H"), FourCC("A0OO"))
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
      SpellSystem.Register(burningVengeance);

      var stormEarthandFire = new StormEarthandFire(Constants.ABILITY_A0HM_STORM_EARTH_AND_FIRE_WARSONG_CHEN_SUMMON)
      {
          UnitType1 = FourCC("npn4"),
          UnitType2 = FourCC("npn5"),
          UnitType3 = FourCC("npn6"),
        /// <summary>
        /// How long the summoned units last.
        /// </summary>
          Duration = 60.0F,
          EffectTarget = "Abilities\\Spells\\Items\\AIil\\AIilTarget.mdl",
          EffectScaleTarget = 1.0F,
          HealthBonusBase = -0.15F,
          HealthBonusLevel = 0.15F,     //The level ones are for each additional hero level, including level 1
          DamageBonusBase = -0.15F,
          DamageBonusLevel = 0.15F
      };
      SpellSystem.Register(stormEarthandFire);
      //Todo: inappropriately named
      var manaSyphon = new GrantMana(Constants.ABILITY_A0RG_MANA_SYPHON_ARATHOR_MAGE_TOWER)
      {
        ManaToGrant = 250
      };
      SpellSystem.Register(manaSyphon);

      var demonSoulCooldown = new CooldownReset(Constants.ABILITY_A0HF_ABILITY_COOLDOWN_RESET);
      SpellSystem.Register(demonSoulCooldown);

      var overclock = new CooldownReset(Constants.ABILITY_A0RA_OVERCLOCK_GAZLOWEE);
      SpellSystem.Register(overclock);

      var ascendance = new Ascendance(Constants.ABILITY_AEME_ASCENDANCE_TEAL_ZULUHED)
      {
        DurationBase = 15,
        DurationLevel = 15,
        HealBase = 50,
        HealLevel = 100,
        Radius = 600,
        AbilitiesToRemove = new[]
        {
          Constants.ABILITY_HEAL_HEALING_WAVE_TEAL_ZULUHED,
          Constants.ABILITY_A0B4_BLOODLUST_TOTEM_TEAL_ZULUHED,
          Constants.ABILITY_AHAB_BRILLIANCE_AURA_ZULUHED_JAINA_MALFURION_VOL_JIN,
          Constants.ABILITY_AEME_ASCENDANCE_TEAL_ZULUHED
        }
      };
      SpellSystem.Register(ascendance);

      var unholyArmor = new UnholyArmor(Constants.ABILITY_A0F8_UNHOLY_ARMOR_FEL_HORDE_FEL_WARLOCK)
      {
        PercentageDamage = 0.06f
      };
      SpellSystem.Register(unholyArmor);

      var hideousAppendagesCthun = new HideousAppendages(Constants.UNIT_U00R_OLD_GOD)
      {
        TentacleCount = 5,
        TentacleUnitTypeId = Constants.UNIT_N073_CTHUNTENTACLE,
        RadiusOffset = 300
      };
      SpellSystem.Register(hideousAppendagesCthun);

      var hideousAppendagesYogg = new HideousAppendages(Constants.UNIT_U02C_OLD_GOD)
      {
        TentacleCount = 5,
        TentacleUnitTypeId = Constants.UNIT_N0B7_YOGGTENTACLE,
        RadiusOffset = 500
      };
      SpellSystem.Register(hideousAppendagesYogg);

      var hideousAppendagesNzoth = new HideousAppendages(Constants.UNIT_U01Z_OLD_GOD_NAGA)
      {
        TentacleCount = 6,
        TentacleUnitTypeId = Constants.UNIT_N098_NZOTHTENTACLE,
        RadiusOffset = 250
      };
      SpellSystem.Register(hideousAppendagesNzoth);

      var corruptBuilding = new CorruptBuildingSpell(Constants.ABILITY_A0N8_CORRUPT_FORSAKEN, 6, 500);
      SpellSystem.Register(corruptBuilding);

      SpellSystem.Register(new RegionRestricted(Constants.UNIT_H097_GUARD_POST_SCARLET,
        new[]
        {
          Regions.HeartglenTaxe,
          Regions.StrahnbradTaxe,
          Regions.AndhoralTaxe,
          Regions.TirisfalTaxe,
          Regions.HavenshireTaxe,
          Regions.CorinTaxe
        }));

      SpellSystem.Register(new ProvidesIncome(Constants.UNIT_H09N_PALISADE_FORT_SCARLET, 15));
      SpellSystem.Register(new ProvidesIncome(Constants.UNIT_H09P_SCARLET_KEEP_SCARLET, 60));
      SpellSystem.Register(new ProvidesIncome(Constants.UNIT_H09O_CRIMSON_CASTLE_SCARLET, 80));
      SpellSystem.Register(new ProvidesIncome(Constants.UNIT_H09Q_ROYAL_FORTRESS_SCARLET, 100));

      FrostwolfSpellSetup.Setup();
      LegionSpellSetup.Setup();
      GoblinSpellSetup.Setup();
      ScourgeSpellSetup.Setup();
      LordaeronSpellSetup.Setup();
      DruidsSpellSetup.Setup();
    }
  }
}