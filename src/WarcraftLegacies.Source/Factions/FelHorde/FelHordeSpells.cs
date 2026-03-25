using MacroTools.Spells;
using MacroTools.UnitTraits;
using WarcraftLegacies.Source.Factions.FelHorde.Spells;
using WarcraftLegacies.Source.Shared.Spells;
using WarcraftLegacies.Source.Shared.Spells.HealingWavePlus;

namespace WarcraftLegacies.Source.Factions.FelHorde;

/// <summary>
/// Responsible for setting up all Fel Horde <see cref="Spell"/>s and <see cref="UnitTrait"/>s.
/// </summary>
public static class FelHordeSpells
{
  /// <summary>
  /// Sets up <see cref="FelHordeSpells"/>.
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

    var warStompKazzak = new MassAnySpell(ABILITY_A0AW_WAR_STOMP_DOOM_LORD)
    {
      Radius = 300,
      Damage = new LeveledAbilityField<float>
      {
        Base = 25
      },
      DummyAbilityId = ABILITY_YBAS_STUN_UNIT_DUMMY_CASTER_WAR_STOMP_DOOM_LORD,
      DummyAbilityOrderId = ORDER_THUNDERBOLT,
      SpecialEffect = @"Abilities\Spells\Orc\WarStomp\WarStompCaster.mdl",
      CastFilter = CastFilters.IsTargetEnemyAliveAndGroundUnits,
      TargetType = SpellTargetType.None
    };
    SpellRegistry.Register(warStompKazzak);

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
