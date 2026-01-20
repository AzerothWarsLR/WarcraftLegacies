using MacroTools.Spells;
using MacroTools.UnitTraits;
using WarcraftLegacies.Source.Spells;
using WarcraftLegacies.Source.UnitTypeTraits;

namespace WarcraftLegacies.Source.Setup.Spells;

public static class WarsongSpellSetup
{
  /// <summary>
  /// Sets up <see cref="WarsongSpellSetup"/>.
  /// </summary>
  public static void Setup()
  {
    UnitTypeTraitRegistry.Register(new Execute
    {
      DamageMultNonResistant = 4,
      DamageMultResistant = 1.5f,
      DamageMultStructure = 1
    }, UNIT_OGRH_CHIEFTAIN_OF_THE_WARSONG_CLAN_WARSONG);

    var voodooHex = new InspireMadness(ABILITY_MD28_VOODOO_HEX_ROKHAN)
    {
      Radius = 400,
      CountBase = 5,
      CountLevel = 5,
      Duration = 60,
      ChancePercentage = 60.0f,
      EffectTarget = @"Abilities\Spells\Other\Charm\CharmTarget.mdl",
      EffectScaleTarget = 0.5f
    };
    SpellRegistry.Register(voodooHex);

    UnitTypeTraitRegistry.Register(new ResoluteHeart(ABILITY_A0TY_RESOLUTE_HEART_ICON)
    {
      Radius = 300f,
      BaseProcChance = 0.1f,
      EffectPath = @"Abilities\Spells\Human\Heal\HealTarget.mdl"
    }, UNIT_O06L_WARLORD_OF_THE_WARSONG_CLAN_WARSONG);

    var stormEarthandFire = new StormEarthandFire(ABILITY_A0HM_STORM_EARTH_AND_FIRE_WARSONG_CHEN_SUMMON)
    {
      UnitType1 = UNIT_NPN4_FIRE_CHEN,
      UnitType2 = UNIT_NPN5_STORM_CHEN,
      UnitType3 = UNIT_NPN6_EARTH_CHEN,
      Duration = 60.0F,
      EffectTarget = @"Abilities\Spells\Items\AIil\AIilTarget.mdl",
      EffectScaleTarget = 1.0F,
      HealthBonusBase = -0.15F,
      HealthBonusLevel = 0.15F,
      DamageBonusBase = -0.15F,
      DamageBonusLevel = 0.15F
    };
    SpellRegistry.Register(stormEarthandFire);
  }
}
