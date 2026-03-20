using MacroTools.Spells;
using WarcraftLegacies.Source.Spells;

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
  }
}
