using MacroTools.Shared;
using static MacroTools.Shared.UnitCategory;

namespace WarcraftLegacies.Shared.FactionObjectLimits;

public static class TaurenTribesObjectInfo
{
  private const int Unlimited = 200;

  public static IEnumerable<ObjectInfo> GetAllObjectLimits()
  {
    yield return new(UNIT_OTNT_TAUREN_CAMP_TAUREN_TRIBES, 1, TownHall);
    yield return new(UNIT_OTWC_WAR_CAMP_TAUREN_TRIBES, 1, Barracks);
    yield return new(UNIT_OTBE_BEASTIARY_TAUREN_TRIBES, 1, Specialist);
    yield return new(UNIT_OTSL_SPIRIT_LODGE_TAUREN_TRIBES, 1, Magic);
    yield return new(UNIT_OTKO_PACK_KODO_TAUREN_TRIBES, Unlimited);
    yield return new(UNIT_OTGD_TAUREN_GUARD_TAUREN_TRIBES, Unlimited);

    yield return new(UPGRADE_RTLM_START_THE_LONG_MARCH_TAUREN_TRIBES, 1);
  }
}
