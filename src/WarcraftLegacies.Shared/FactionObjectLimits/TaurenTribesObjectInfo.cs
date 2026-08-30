using MacroTools.Shared;
using static MacroTools.Shared.UnitCategory;

namespace WarcraftLegacies.Shared.FactionObjectLimits;

public static class TaurenTribesObjectInfo
{
  public static IEnumerable<ObjectInfo> GetAllObjectLimits()
  {
    yield return new(UNIT_OTNT_TAUREN_CAMP_TAUREN_TRIBES, 1, TownHall);
    //yield return new(UNIT_OTWC_WAR_CAMP_TAUREN_TRIBES, 1, Barracks);
    yield return new(UNIT_OTBE_BEASTIARY_TAUREN_TRIBES, 1, Specialist);
    yield return new(UNIT_OTSL_SPIRIT_LODGE_TAUREN_TRIBES, 1, Magic);
  }
}
