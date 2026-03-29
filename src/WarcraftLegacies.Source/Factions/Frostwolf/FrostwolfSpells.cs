using MacroTools.Spells;
using WarcraftLegacies.Source.Factions.Frostwolf.Spells;
using WarcraftLegacies.Source.Shared.Spells;

namespace WarcraftLegacies.Source.Factions.Frostwolf;

public static class FrostwolfSpells
{
  public static void Setup()
  {
    var devour = new Devour(ABILITY_ADEV_DEVOUR_KODO_BEAST)
    {
      PercentageOfMaxHealth = 0.5f
    };
    SpellRegistry.Register(devour);

    var cripplingShout = new MassAnySpell(ABILITY_TP07_CRIPPLING_SHOUT_FROSTWOLF)
    {
      Radius = 700,
      DummyAbilityId = ABILITY_TP08_CRIPPLE_DUMMY,
      DummyAbilityOrderId = ORDER_CRIPPLE,
      SpecialEffect = @"abilities\spells\nightelf\battleroar\roarcaster.mdx",
      CastFilter = CastFilters.IsTargetEnemyAndAliveUnits,
      TargetType = SpellTargetType.None
    };
    SpellRegistry.Register(cripplingShout);

    SpellRegistry.Register(new AncestralLegion(ABILITY_A0YX_ANCESTRAL_LEGION_FROSTWOLF_CAIRNE)
    {
      Duration = 60,
      HealthBonus = new LeveledAbilityField<float>
      {
        Base = 0.2f,
        PerLevel = 0.1f
      },
      DamageBonus = new LeveledAbilityField<float>
      {
        Base = 0.2f,
        PerLevel = 0.1f
      },
      SummonCap = new LeveledAbilityField<int>
      {
        Base = 6,
        PerLevel = 6
      },
      RememberChance = 1f,
      RememberableUnitTypeId = UNIT_OTAU_TAUREN_FROSTWOLF,
      SummonEffect = @"Abilities\Spells\Demon\DarkPortal\DarkPortalTarget.mdl",
      DeathEffect = @"Abilities\Spells\Orc\Disenchant\DisenchantSpecialArt.mdl"
    });
  }
}
