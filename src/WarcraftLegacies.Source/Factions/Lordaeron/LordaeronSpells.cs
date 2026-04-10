using MacroTools.Spells;
using WarcraftLegacies.Source.Factions.Lordaeron.Spells;
using WarcraftLegacies.Source.Factions.Lordaeron.Spells.ExactJustice;
using WarcraftLegacies.Source.Factions.Lordaeron.Spells.HallowedLight;
using WarcraftLegacies.Source.Shared.Spells;

namespace WarcraftLegacies.Source.Factions.Lordaeron;

public static class LordaeronSpells
{
  public static void Setup()
  {
    var consecration = new MassAnySpell(ABILITY_A0WE_CONSECRATION_LORDAERON_UTHER)
    {
      Radius = 300,
      Damage = new LeveledAbilityField<float>
      {
        Base = 20,
        PerLevel = 40
      },
      DummyAbilityId = ABILITY_S00H_THUNDER_CLAP_DUMMY,
      DummyAbilityOrderId = ORDER_CRIPPLE,
      SpecialEffect = @"Abilities\Spells\Human\Thunderclap\ThunderClapCaster.mdl",
      CastFilter = CastFilters.IsTargetEnemyAliveAndGroundUnits,
      TargetType = SpellTargetType.None
    };
    SpellRegistry.Register(consecration);

    var solarJudgement = new SolarJudgementSpell(ABILITY_A01F_SOLAR_JUDGEMENT_LORDAERON_ARTHAS)
    {
      DamageBase = 0,
      DamageLevel = 25,
      Duration = 10,
      Period = 0.25f,
      HealMultiplier = 1.5f,
      UndeadDamageMultiplier = 1.1f,
      Radius = 250,
      BoltRadius = 125,
      EffectPath = "Shining Flare.mdx",
      EffectHealPath = @"Abilities\Spells\Human\Heal\HealTarget.mdl"
    };
    SpellRegistry.Register(solarJudgement);

    SpellRegistry.Register(new HallowedLight(ABILITY_A043_HALLOWED_LIGHT_PALADIN)
    {
      Duration = 7.0f,
      BuffEffect = "war3mapImported\\Soul Armor Radiant_opt.mdx",
      DebuffEffect = "war3mapImported\\Soul Armor Crimson_opt.mdx"
    });
    var exactJustice = new ExactJusticeSpell(ABILITY_A097_EXACT_JUSTICE_UTHER)
    {
      DamageBase = 0,
      DamageLevel = 200,
      Radius = 400,
      EffectSettings = new ExactJusticeEffectSettings
      {
        SparklePath = "war3mapImported\\Consecrate.mdx",
        SparkleScale = 2.3f,
        RingPath = "war3mapImported\\Point Target.mdx",
        RingScale = 5.5f,
        ProgressBarPath = "war3mapImported\\Progressbar.mdx",
        ProgressBarScale = 1.5f,
        ProgressBarHeight = 225f,
        ExplodePath = "war3mapImported\\Divine Edict.mdx",
        ExplodeScale = 2,
        AlphaRing = 255f,
        AlphaFade = 0.5f
      }
    };
    SpellRegistry.Register(exactJustice);
  }
}
