using MacroTools.Shared;
using static MacroTools.Shared.UnitCategory;

namespace WarcraftLegacies.Shared.FactionObjectLimits;

public static class OrcishHordeObjectInfo
{
  private const int Unlimited = 200;

  public static IEnumerable<ObjectInfo> GetAllObjectLimits()
  {
    yield return new(UNIT_O078_GREAT_HALL_ORCISH_HORDE_T1, Unlimited, TownHall);
    yield return new(UNIT_O076_ALTAR_OF_STORMS_ORCISH_HORDE, Unlimited, Altar);
    yield return new(UNIT_O075_WAR_CAMP_ORCISH_HORDE, Unlimited, Barracks);

    yield return new(UNIT_O07A_PEON_ORCISH_HORDE, Unlimited, Builder);
    yield return new(UNIT_O074_GRUNT_ORCISH_HORDE, Unlimited, Fighter);

    yield return new(UNIT_O077_THRALL_ORCISH_HORDE, 1, new List<UnitCategory> { Destroyer, Summoner });
  }
}
