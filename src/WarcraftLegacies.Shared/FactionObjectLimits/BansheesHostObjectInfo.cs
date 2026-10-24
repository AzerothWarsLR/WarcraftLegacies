using MacroTools.Shared;

namespace WarcraftLegacies.Shared.FactionObjectLimits;

/// <summary>A placeholder roster for the Banshee's Host: the Scourge's, with smaller limits.</summary>
public static class BansheesHostObjectInfo
{
  private const int Unlimited = 200;

  public static IEnumerable<ObjectInfo> GetAllObjectLimits()
  {
    foreach (var objectInfo in ScourgeObjectInfo.GetAllObjectLimits())
    {
      if (IsExcluded(objectInfo.ObjectTypeId))
      {
        continue;
      }

      yield return new ObjectInfo(objectInfo.ObjectTypeId, GetLimit(objectInfo), objectInfo.Categories);
    }
  }

  private static bool IsExcluded(int objectTypeId) =>
    objectTypeId == UNIT_ZBLI_LICH_SCOURGE_ELITE ||
    objectTypeId == UNIT_H00H_DEATH_KNIGHT_SCOURGE_ELITE ||
    objectTypeId == UPGRADE_ZB74_LICHES_SCOURGE ||
    objectTypeId == UPGRADE_ZB24_DEATH_KNIGHTS_SCOURGE ||
    objectTypeId == UNIT_UEAR_CHAMPION_OF_THE_SCOURGE_SCOURGE ||
    objectTypeId == UNIT_UBDD_SAPPHIRON_SCOURGE_DEMI ||
    objectTypeId == UNIT_UANB_KING_OF_AZJOL_NERUB_SCOURGE ||
    objectTypeId == UNIT_U001_MASTER_OF_THE_CULT_OF_THE_DAMNED_SCOURGE_NECROMANCER ||
    objectTypeId == UNIT_U00M_MASTER_OF_THE_CULT_OF_THE_DAMNED_SCOURGE_GHOST ||
    objectTypeId == UNIT_U00A_SCOURGE_COMMANDER_SCOURGE ||
    objectTypeId == UNIT_UKTL_ARCHLICH_OF_THE_SCOURGE_SCOURGE_LICH;

  private static int GetLimit(ObjectInfo objectInfo)
  {
    if (objectInfo.Limit <= 1 || objectInfo.Limit >= Unlimited)
    {
      return objectInfo.Limit;
    }

    return Math.Max(1, objectInfo.Limit / 2);
  }
}
