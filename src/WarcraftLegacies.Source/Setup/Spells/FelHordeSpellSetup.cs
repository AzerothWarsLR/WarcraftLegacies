using MacroTools.PassiveAbilities;
using MacroTools.PassiveAbilitySystem;
using MacroTools.Spells;
using MacroTools.SpellSystem;
using WarcraftLegacies.Source.Spells;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Spells
{
  /// <summary>
  /// Responsible for setting up all Fel Horde <see cref="Spell"/>s and <see cref="PassiveAbility"/>s.
  /// </summary>
  public static class FelHordeSpellSetup
  {
    /// <summary>
    /// Sets up <see cref="FelHordeSpellSetup"/>.
    /// </summary>
    public static void Setup()
    {
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
          Constants.ABILITY_AHAB_BRILLIANCE_AURA_ZULUHED_JAINA_MALFURION_VOL_JIN_JERGOSH,
          Constants.ABILITY_AEME_ASCENDANCE_TEAL_ZULUHED
        }
      };
      SpellSystem.Register(ascendance);
      
      var warStompKazzak = new Stomp(Constants.ABILITY_A0AW_WAR_STOMP_BLUE_DOOM_GUARD_TEAL_KAZZAK)
      {
        Radius = 300,
        DamageBase = 25,
        DurationBase = 3,
        StunAbilityId = Constants.ABILITY_A0WN_STUN_UNIT_DUMMY,
        StunOrderId = OrderId("thunderbolt"),
        SpecialEffect = @"Abilities\Spells\Orc\WarStomp\WarStompCaster.mdl"
      };
      SpellSystem.Register(warStompKazzak);

      PassiveAbilityManager.Register(new SummonUnitOnDeath(Constants.UNIT_NCHG_FEL_GRUNT_FEL_HORDE)
      {
        Duration = 40,
        SummonUnitTypeId = Constants.UNIT_N00O_SKELETAL_GRUNT_FEL_HORDE,
        SummonCount = 1,
        SpecialEffectPath = @"Abilities\Spells\Undead\RaiseSkeletonWarrior\RaiseSkeleton.mdl",
        RequiredResearch = Constants.UPGRADE_R098_FEL_INFUSED_SKELETON_FEL_HORDE
      });

      PassiveAbilityManager.Register(new Execute(Constants.UNIT_O01L_EXECUTIONER_FEL_HORDE_ELITE)
      {
        DamageMultNonResistant = 4,
        DamageMultResistant = 2,
        DamageMultStructure = 1
      });

      PassiveAbilityManager.Register(new Execute(Constants.UNIT_N0B4_REAPER_YOGG)
      {
        DamageMultNonResistant = 4,
        DamageMultResistant = 2,
        DamageMultStructure = 1
      });

      SpellSystem.Register(new Devour(Constants.ABILITY_A0TU_DEVOUR_BLACK_DRAKE)
      {
        PercentageOfMaxHealth = 0.5f
      });
    }
  }
}