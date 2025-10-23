using MacroTools.Spells;
using MacroTools.UnitTypeTraits;
using WarcraftLegacies.Source.Spells;
using WarcraftLegacies.Source.Spells.HealingWavePlus;
using WarcraftLegacies.Source.UnitTypeTraits;


namespace WarcraftLegacies.Source.Setup.Spells;

/// <summary>
/// Responsible for setting up all Fel Horde <see cref="Spell"/>s and <see cref="UnitTypeTrait"/>s.
/// </summary>
public static class FelHordeSpellSetup
{
  /// <summary>
  /// Sets up <see cref="FelHordeSpellSetup"/>.
  /// </summary>
  public static void Setup()
  {
    var ascendance = new Ascendance(ABILITY_AEME_ASCENDANCE_TEAL_ZULUHED)
    {
      DurationBase = 15,
      DurationLevel = 15,
      HealBase = 50,
      HealLevel = 100,
      Radius = 600,
      AbilitiesToRemove = new[]
      {
        ABILITY_HEAL_HEALING_WAVE_TEAL_ZULUHED,
        ABILITY_A0B4_BLOODLUST_TOTEM_TEAL_ZULUHED,
        ABILITY_AHAB_BRILLIANCE_AURA_ZULUHED_JAINA_MALFURION_VOL_JIN_JERGOSH,
        ABILITY_AEME_ASCENDANCE_TEAL_ZULUHED
      }
    };
    SpellRegistry.Register(ascendance);

    var healingWavePlusHero = new HealingWavePlus(ABILITY_HWP4_ENERGY_WAVE_TERON)
    {
      DeathTriggerDuration = 20.0f,
      HealAmountBase = 100.0f,
      HealAmountLevel = 0.0f,
      MaxBounces = 3,
      BounceRadius = 500.0f,
      SecondaryWaveRadius = 500.0f,
      SecondWaveHealAmount = 100.0f,
      HealingEffect = @"",
      TargetMarkEffect = @""
    };
    SpellRegistry.Register(healingWavePlusHero);


    var warStompKazzak = new Stomp(ABILITY_A0AW_WAR_STOMP_BLUE_DOOM_GUARD_TEAL_KAZZAK)
    {
      Radius = 300,
      DamageBase = 25,
      DurationBase = 3,
      StunAbilityId = ABILITY_A0WN_STUN_UNIT_DUMMY,
      StunOrderId = ORDER_THUNDERBOLT,
      SpecialEffect = @"Abilities\Spells\Orc\WarStomp\WarStompCaster.mdl"
    };
    SpellRegistry.Register(warStompKazzak);

    UnitTypeTraitRegistry.Register(new SummonUnitOnDeath
    {
      Duration = 40,
      SummonUnitTypeId = UNIT_N00O_SKELETAL_GRUNT_FEL,
      SummonCount = 1,
      SpecialEffectPath = @"Abilities\Spells\Undead\RaiseSkeletonWarrior\RaiseSkeleton.mdl",
      RequiredResearch = UPGRADE_R098_FEL_INFUSED_SKELETON_FEL_HORDE
    }, UNIT_NCHG_FEL_GRUNT_FEL);


    UnitTypeTraitRegistry.Register(new Execute
    {
      DamageMultNonResistant = 4,
      DamageMultResistant = 2,
      DamageMultStructure = 1
    }, UNIT_O01L_EXECUTIONER_FEL_ELITE);

    UnitTypeTraitRegistry.Register(new Execute
    {
      DamageMultNonResistant = 4,
      DamageMultResistant = 2,
      DamageMultStructure = 1
    }, UNIT_N0B4_REAPER_NZOTH);

    SpellRegistry.Register(new Devour(ABILITY_A0TU_DEVOUR_BLACK_DRAKE)
    {
      PercentageOfMaxHealth = 0.5f
    });

    var unholyArmor = new UnholyArmor(ABILITY_A0F8_UNHOLY_ARMOR_FEL_HORDE_FEL_WARLOCK)
    {
      PercentageDamage = 0.06f
    };
    SpellRegistry.Register(unholyArmor);
  }
}
