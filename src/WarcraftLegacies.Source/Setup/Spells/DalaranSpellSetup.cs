using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.SpellSystem;
using WarcraftLegacies.Source.Spells;

namespace WarcraftLegacies.Source.Setup.Spells;

public static class DalaranSpellSetup
{
  /// <summary>
  /// Sets up <see cref="DalaranSpellSetup"/>.
  /// </summary>
  public static void Setup()
  {
    var enchantedBolt = new MassAnySpell(ABILITY_A10L_ENCHANTED_BOLTS_DALARAN)
    {
      DummyAbilityId = ABILITY_A10O_ENCHANTED_BOLT_DALARAN_DUMMY,
      DummyAbilityOrderId = ORDER_THUNDERBOLT,
      Radius = 250,
      CastFilter = CastFilters.IsTargetEnemyAndAlive,
      TargetType = SpellTargetType.Point,
      DummyCastOriginType = DummyCastOriginType.Caster
    };
    SpellSystem.Register(enchantedBolt);

    SpellSystem.Register(new ChannelAnySpellCaster(ABILITY_A11A_TIME_S_SHIELD_DALARAN_2)
    {
      DummyAbilityId = ABILITY_A11K_TIME_S_SHIELD_DALARAN_DUMMY,
      DummyAbilityOrderId = ORDER_VOODOO,
      Duration = 4
    });

    var rebornTime = new CooldownReset(ABILITY_A10T_REBORN_THROUGH_TIME_DALARAN);
    SpellSystem.Register(rebornTime);

    var massIceLance = new MassAnySpell(ABILITY_A0J0_MASS_ICE_LANCE_NEXUS)
    {
      DummyAbilityId = ABILITY_A0IK_MASS_ICE_LANCE_NEXUS_DUMMY,
      DummyAbilityOrderId = ORDER_THUNDERBOLT,
      Radius = 250,
      CastFilter = CastFilters.IsTargetEnemyAndAlive,
      TargetType = SpellTargetType.Point,
      DummyCastOriginType = DummyCastOriginType.Caster
    };
    SpellSystem.Register(massIceLance);

    var massSimulacrum = new MassSimulacrum(ABILITY_A0DG_MASS_SIMULACRUM_ORANGE_ANTONIDAS)
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
  }
}
