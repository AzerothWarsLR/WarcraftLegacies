using MacroTools.Shared;

namespace WarcraftLegacies.Shared.FactionObjectLimits;

/// <summary>A placeholder roster for Theramore: Dalaran's, with smaller limits and Jaina as the only hero.</summary>
public static class TheramoreObjectInfo
{
  private const int Unlimited = 200;

  public static IEnumerable<ObjectInfo> GetAllObjectLimits()
  {
    foreach (var objectInfo in DalaranObjectInfo.GetAllObjectLimits())
    {
      if (IsExcluded(objectInfo.ObjectTypeId))
      {
        continue;
      }

      yield return new ObjectInfo(objectInfo.ObjectTypeId, GetLimit(objectInfo), objectInfo.Categories);
    }
  }

  private static bool IsExcluded(int objectTypeId) =>
    objectTypeId == UNIT_HANT_GRAND_MAGUS_OF_THE_KIRIN_TOR_DALARAN ||
    objectTypeId == UNIT_H09N_MATRIARCH_OF_TIRISFAL_DALARAN ||
    objectTypeId == UNIT_HAAH_THE_FALLEN_GUARDIAN_DALARAN;

  private static int GetLimit(ObjectInfo objectInfo)
  {
    if (objectInfo.Limit <= 1 || objectInfo.Limit >= Unlimited)
    {
      return objectInfo.Limit;
    }

    return Math.Max(1, objectInfo.Limit / 2);
  }
}
