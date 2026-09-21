using MacroTools.Spells;
using WarcraftLegacies.Source.Factions.Quelthalas.Spells;
using WarcraftLegacies.Source.Shared.Spells;

namespace WarcraftLegacies.Source.Factions.Quelthalas;

public static class QuelthalasSpells
{
  public static void Setup()
  {
    var summonGraniteGolems = new SummonUnits(ABILITY_A0EP_SUMMON_GRANITE_GOLEMS_QUEL_THALAS_SUNWELL)
    {
      SummonUnitTypeId = UNIT_NGGR_GRANITE_GOLEM_QUELTHALAS,
      SummonCount = 4,
      Duration = 60,
      Radius = 400,
      AngleOffset = 45,
      Effect = @"war3mapImported\Earth NovaTarget.mdx"
    };
    SpellRegistry.Register(summonGraniteGolems);

    SpellRegistry.Register(new ChainManaBurn(ABILITY_ZBCM_CHAIN_MANA_BURN_ROMMATH)
    {
      ManaBurned = new LeveledAbilityField<int>
      {
        Base = 100,
        PerLevel = 100
      },
      MaximumBounces = 7,
      BurnReductionPerBounce = 0.1f,
      MaximumBounceRadius = 500
    });

    SpellRegistry.Register(new SunfireBarrageSpell(ABILITY_A14K_SUNFIRE_BARRAGE_ANASTERIAN)
    {
      FireballDamage = new LeveledAbilityField<float> { Base = 70, PerLevel = 105 },
      OrbDamage = new LeveledAbilityField<float> { Base = 21, PerLevel = 21 },
      OrbBlastRadius = 150,
      FireballSpeed = 900,
      OrbSpeed = 1200,
      Effects = new SunfireBarrageEffectSettings
      {
        FireballPath = @"Abilities\Weapons\FireBallMissile\FireBallMissile.mdl",
        FireballScale = 2,
        FireballExplosionPath = @"Abilities\Spells\Other\Incinerate\FireLordDeathExplode.mdl",
        FireballExplosionScale = 2,
        OrbExplosionPath = @"Abilities\Spells\Other\Incinerate\FireLordDeathExplode.mdl",
        OrbExplosionScale = 0.7f
      }
    });
  }
}
