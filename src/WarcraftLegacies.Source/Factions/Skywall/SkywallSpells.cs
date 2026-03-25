using MacroTools.Spells;
using WarcraftLegacies.Source.Factions.Skywall.Spells;
using WarcraftLegacies.Source.Factions.Skywall.Spells.WarpedMalediction;
using WarcraftLegacies.Source.Factions.Skywall.Spells.WhimOfTheWinds;
using WarcraftLegacies.Source.Shared.Spells;

namespace WarcraftLegacies.Source.Factions.Skywall;

public static class SkywallSpells
{
  public static void Setup()
  {
    var earthProtectionHero = new AnySpellNoTarget(ABILITY_A0Y4_EARTH_PROTECTION_ELEMENTAL_LORD)
    {
      DummyAbilityId = ABILITY_A0XY_EARTH_PROTECTION_HERO_DUMMY,
      DummyAbilityOrderId = ORDER_ROAR
    };
    SpellRegistry.Register(earthProtectionHero);

    var stormSurge = new MassAnySpell(ABILITY_A104_STORM_SURGE_SKYWALL)
    {
      DummyAbilityId = ABILITY_TP04_PURGE_DUMMY,
      DummyAbilityOrderId = ORDER_PURGE,
      Radius = 200,
      Damage = new LeveledAbilityField<float>
      {
        Base = 30,
        PerLevel = 20
      },
      TargetType = SpellTargetType.Point,
      CastFilter = CastFilters.IsTargetEnemyAndAlive
    };
    SpellRegistry.Register(stormSurge);

    var massEnsnare = new MassAnySpell(ABILITY_A01N_MASS_ENSNARE_SKYWALL)
    {
      DummyAbilityId = ABILITY_A01V_MASS_ENSNARE_SKYWALL_DUMMY,
      DummyAbilityOrderId = ORDER_ENSNARE,
      Radius = 250,
      CastFilter = (caster, target) => CastFilters.IsTargetEnemyAndAlive(caster, target) && GetRandomReal(0, 1) <= 0.75,
      TargetType = SpellTargetType.Point
    };
    SpellRegistry.Register(massEnsnare);

    var whimOfTheWinds = new WhimOfTheWinds(ABILITY_WOTW_WHIM_OF_THE_WINDS_SKYWALL);
    SpellRegistry.Register(whimOfTheWinds);

    var warpedMalediction = new WarpedMalediction(ABILITY_WMTP_WARPED_MALEDICTION_SKYWALL);
    SpellRegistry.Register(warpedMalediction);
  }
}
