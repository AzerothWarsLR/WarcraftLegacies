using MacroTools.Spells;
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
  }
}
