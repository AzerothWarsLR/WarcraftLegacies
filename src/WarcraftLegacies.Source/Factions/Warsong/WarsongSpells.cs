using MacroTools.Spells;
using WarcraftLegacies.Source.Factions.Warsong.Spells;
using WarcraftLegacies.Source.Shared.Spells;

namespace WarcraftLegacies.Source.Factions.Warsong;

public static class WarsongSpells
{
  /// <summary>
  /// Sets up <see cref="WarsongSpells"/>.
  /// </summary>
  public static void Setup()
  {
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
