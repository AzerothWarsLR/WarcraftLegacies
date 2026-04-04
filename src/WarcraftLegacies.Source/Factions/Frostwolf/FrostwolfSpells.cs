using MacroTools.Spells;
using WarcraftLegacies.Source.Shared.Spells;
using WarcraftLegacies.Source.Shared.Spells.Slipstream;
using WCSharp.Shared.Data;

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

    SpellRegistry.Register(new SlipstreamSpellSpecificDestination(ABILITY_A0ZJ_PORTAL_TO_NAGRAND_ITEM)
    {
      PortalUnitTypeId = UNIT_N0D9_SLIPSTREAM_PORTAL_STORMWIND_KHADGAR,
      OpeningDelay = 5,
      ClosingDelay = 10,
      TargetLocation = new Point(-3169, -29714),
      Color = new Color(255, 50, 50, 255)
    });
  }
}
