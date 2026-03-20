using MacroTools.DummyCasters;
using MacroTools.Spells;
using WarcraftLegacies.Source.Spells;

namespace WarcraftLegacies.Source.Factions.BlackEmpire;

public static class BlackEmpireSpells
{
  public static void Setup()
  {
    var poisonYor = new MassAnySpell(ABILITY_ABNT_VOID_TOXIN_BLACK_EMPIRE)
    {
      Radius = 500,
      Damage = new LeveledAbilityField<float>
      {
        Base = 60,
        PerLevel = 20
      },
      DummyAbilityId = ABILITY_ABSS_SHADOW_STRIKE_VOID_TOXIN_REAL,
      DummyAbilityOrderId = ORDER_SHADOWSTRIKE,
      SpecialEffect = @"Abilities\Weapons\ChimaeraAcidMissile\ChimaeraAcidMissile.mdl",
      CastFilter = CastFilters.IsTargetEnemyAliveAndGroundUnits,
      DummyCastOriginType = DummyCastOriginType.Caster,
      TargetType = SpellTargetType.None
    };
    SpellRegistry.Register(poisonYor);

    var massBanish = new MassAnySpell(ABILITY_MD29_MASS_BANISH_BLACK_EMPIRE_ZA_QUL)
    {
      DummyAbilityId = ABILITY_MD30_MASS_BANISH_BLACK_EMPIRE_ZA_QUL_DUMMY_CASTER,
      DummyAbilityOrderId = ORDER_BANISH,
      Radius = 250,
      CastFilter = CastFilters.IsTargetOrganicAndAlive,
      TargetType = SpellTargetType.Point
    };
    SpellRegistry.Register(massBanish);

    var siphoningRitual = new SiphoningRitual(ABILITY_MD24_SIPHONING_RITUAL_BLACK_EMPIRE_ZON_OOZ)
    {
      TargetCountBase = 24,
      TargetCountLevel = 0,
      LifeDrainedPerSecondBase = 30,
      LifeDrainedPerSecondLevel = 10,
      ManaDrainedPerSecondBase = 15,
      ManaDrainedPerSecondLevel = 5,
      Range = 800,
      Radius = 225,
      Interval = 0.1f
    };
    SpellRegistry.Register(siphoningRitual);

    SpellRegistry.Register(new ChainManaBurn(ABILITY_MD23_CHAIN_MANA_BURN_ZA_QUL)
    {
      ManaBurned = new LeveledAbilityField<int>
      {
        Base = 100,
        PerLevel = 75
      },
      MaximumBounces = 5,
      BurnReductionPerBounce = 0.15f,
      MaximumBounceRadius = 500
    });
  }
}
