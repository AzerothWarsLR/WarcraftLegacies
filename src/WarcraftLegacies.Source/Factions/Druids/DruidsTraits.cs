using MacroTools.UnitTraits;
using WarcraftLegacies.Source.UnitTypeTraits.MassiveAttack;

namespace WarcraftLegacies.Source.Factions.Druids;

public static class DruidsTraits
{
  public static void Setup()
  {
    UnitTypeTraitRegistry.Register(new MassiveAttackAbility
    {
      AttackDamagePercentage = 0.5f,
      Distance = 700
    }, UNIT_E00A_ANCIENT_GUARDIAN_DRUIDS);
  }
}
