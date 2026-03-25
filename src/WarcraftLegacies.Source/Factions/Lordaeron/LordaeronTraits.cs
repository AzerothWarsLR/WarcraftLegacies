using MacroTools.UnitTraits;
using WarcraftLegacies.Source.Shared.UnitTraits;

namespace WarcraftLegacies.Source.Factions.Lordaeron;

public static class LordaeronTraits
{
  public static void Setup()
  {
    UnitTypeTraitRegistry.Register(new NoTargetSpellOnAttack(ABILITY_A122_WILL_OF_THE_ASHBRINGER_MOGRAINE)
    {
      DummyAbilityId = ABILITY_A0KA_RESURRECTION_DUMMY_MOGRAINE,
      DummyOrderId = ORDER_RESURRECTION,
      ProcChance = 0.2f
    }, UNIT_H01J_THE_ASHBRINGER_LORDAERON);
  }
}
