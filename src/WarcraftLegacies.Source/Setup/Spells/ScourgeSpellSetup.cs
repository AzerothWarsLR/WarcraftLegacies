using MacroTools.PassiveAbilities;
using MacroTools.PassiveAbilitySystem;
using MacroTools.Spells;
using MacroTools.SpellSystem;
using WarcraftLegacies.Source.Mechanics.Scourge;
using WarcraftLegacies.Source.Spells;

namespace WarcraftLegacies.Source.Setup.Spells
{
  /// <summary>
  /// Responsible for setting up all Scourge <see cref="Spell"/>s.
  /// </summary>
  public static class ScourgeSpellSetup
  {
    /// <summary>
    /// Sets up all Scourge <see cref="Spell"/>s.
    /// </summary>
    public static void Setup()
    {
      SpellSystem.Register(new SingleTargetRecall(Constants.ABILITY_A0W8_RECALL_FROZEN_THRONE));

      PassiveAbilityManager.Register(new PersistentSoul(Constants.UNIT_N009_REVENANT_SCOURGE,
        Constants.ABILITY_A05L_PERSISTENT_SOUL_SCOURGE_REVENANT)
      {
        ReanimationCountLevel = 1,
        Duration = 40,
        BuffId = Constants.BUFF_B069_PERSISTENT_SOUL_FORSAKEN_PLAGUE_REVENANT,
        Radius = 700
      });
      Plagueling.Setup(); //Todo: convert this into being a proper passive ability
      
      var massUnholyFrenzy = new MassAnySpell(Constants.ABILITY_A02W_MASS_UNHOLY_FRENZY_SCOURGE)
      {
        DummyAbilityId = Constants.ABILITY_ACUF_UNHOLY_FRENZY_DUMMY,
        DummyAbilityOrderString = "unholyfrenzy",
        Radius = 250,
        CastFilter = CastFilters.IsTargetOrganicAndAlive,
        TargetType = SpellTargetType.Point
      };
      SpellSystem.Register(massUnholyFrenzy);

      var massFrostArmor = new MassAnySpell(Constants.ABILITY_A13R_MASS_FROST_ARMOR_KEL_THUZAD)
      {
        DummyAbilityId = Constants.ABILITY_A13S_MASS_FROST_ARMOUR_KEL_THUZAD_DUMMY,
        DummyAbilityOrderString = "frostarmor",
        Radius = 200,
        CastFilter = CastFilters.IsTargetOrganicAndAlive,
        TargetType = SpellTargetType.Point
      };
      SpellSystem.Register(massFrostArmor);

      var rendSoul = new RendSoul(Constants.ABILITY_ZB01_REND_SOUL_KEL_THUZAD_LICH)
      {
        HitPointsPerTargetMaximumHitPoints = 0.25f,
        ManaPointsPerTargetMaximumHitPoints = 0.35f,
        UnitTypeSummoned = Constants.UNIT_N009_REVENANT_SCOURGE,
        EffectTarget = @"Abilities\Spells\Undead\DarkRitual\DarkRitualTarget.mdl",
        EffectCaster = @"Abilities\Spells\Undead\DarkRitual\DarkRitualCaster.mdl",
        Duration = 45
      };
      SpellSystem.Register(rendSoul);
      
      PassiveAbilityManager.Register(new RemoveOnDeath(Constants.UNIT_N094_ICECROWN_OBELISK_RED)
      {
        DeathEffectPath = @"Objects\Spawnmodels\Undead\UDeathSmall\UDeathSmall.mdl"
      });
      
      SpellSystem.Register(new Reap(Constants.ABILITY_ZB02_REAP_UNDEAD_ARTHAS)
      {
        UnitsSlain = new ()
        {
          Base = 1,
          PerLevel = 2
        },
        StrengthPerUnit = new()
        {
          Base = 5
        },
        Radius = new()
        {
          Base = 500
        },
        Duration = 30,
        KillEffect = @"Objects\Spawnmodels\Undead\UndeadDissipate\UndeadDissipate.mdl",
        BuffEffect = @"Abilities\Spells\Items\AIso\BIsvTarget.mdl"
      });

      var massDeathCoil = new MassAnySpell(Constants.ABILITY_A00E_MASS_DEATH_COIL_ARTHAS)
      {
        DummyAbilityId = Constants.ABILITY_A02T_MASS_DEATH_COIL_ARTHAS_DUMMY,
        DummyAbilityOrderString = "deathcoil",
        Radius = 250,
        CastFilter = CastFilters.IsTargetOrganicAndAlive,
        TargetType = SpellTargetType.Point,
        DummyCastOriginType = DummyCastOriginType.Caster
      };
      SpellSystem.Register(massDeathCoil);
    }
  }
}