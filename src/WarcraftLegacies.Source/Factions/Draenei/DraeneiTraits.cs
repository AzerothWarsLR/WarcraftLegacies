using MacroTools.UnitTraits;
using WarcraftLegacies.Source.Shared.UnitTraits.MassiveAttack;

namespace WarcraftLegacies.Source.Factions.Draenei;

public static class DraeneiTraits
{
  public static void Setup()
  {
    UnitTypeTraitRegistry.Register(new MassiveAttackAbility
    {
      AttackDamagePercentage = 0.3f,
      Distance = 700
    }, UNIT_N0CX_LIGHTFORGED_WARFRAME_DRAENEI);
  }
}
