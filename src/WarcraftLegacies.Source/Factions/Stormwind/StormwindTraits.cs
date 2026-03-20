using MacroTools.UnitTraits;
using WarcraftLegacies.Source.UnitTypeTraits;

namespace WarcraftLegacies.Source.Factions.Stormwind;

public class StormwindTraits
{
  public static void Setup()
  {
    UnitTypeTraitRegistry.Register(new ChannelSpellOnAttack(ABILITY_A12C_LEGENDARY_WARRIOR_VARIAN)
    {
      DummyAbilityId = ABILITY_A12D_LEGENDARY_WARRIOR_STORMWIND_DUMMY,
      DummyOrderId = ORDER_VOODOO,
      ProcChance = 0.15f,
      DurationBase = (int)0.5,
      DurationLevel = (int)0.5
    }, UNIT_H00R_KING_OF_STORMWIND_STORMWIND);
  }
}
