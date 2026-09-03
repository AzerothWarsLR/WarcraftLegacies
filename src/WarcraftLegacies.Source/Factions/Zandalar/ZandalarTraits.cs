using MacroTools.UnitTraits;
using WarcraftLegacies.Source.Factions.Warsong.UnitTraits;
using WarcraftLegacies.Source.Shared.UnitTraits;

namespace WarcraftLegacies.Source.Factions.Warsong;

public static class ZandalarTraits
{
  public static void Setup()
  {
    UnitTypeTraitRegistry.Register(new Execute
    {
      DamageMultNonResistant = 4,
      DamageMultResistant = 1.5f
    }, UNIT_MD44_RAVAGER_ZANDALAR);
  }
}
