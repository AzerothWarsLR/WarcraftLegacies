using System.Diagnostics.CodeAnalysis;
using MacroTools.Shared;
using MacroTools.Shared.Extensions;
using WarcraftLegacies.Shared.FactionObjectLimits;

namespace WarcraftLegacies.Shared;

/// <summary>
/// Provides access to collated, manually configured object information.
/// </summary>
public sealed class ObjectInfoRepository
{
  private readonly Dictionary<string, ObjectInfo> _byObjectId = new();
  private readonly List<ObjectInfo> _all = new();

  /// <summary>
  /// Initializes a new instance of the <see cref="ObjectInfoRepository"/> class.
  /// </summary>
  public ObjectInfoRepository()
  {
    AddFactionObjectInfo(AhnqirajObjectInfo.GetAllObjectInfos());
    AddFactionObjectInfo(BilgewaterObjectInfo.GetAllObjectLimits());
    AddFactionObjectInfo(BlackEmpireObjectInfo.GetAllObjectLimits());
    AddFactionObjectInfo(DalaranObjectInfo.GetAllObjectLimits());
    AddFactionObjectInfo(DraeneiObjectInfo.GetAllObjectLimits());
    AddFactionObjectInfo(DruidsObjectInfo.GetAllObjectLimits());
    AddFactionObjectInfo(FelHordeObjectInfo.GetAllObjectInfos());
    AddFactionObjectInfo(FrostwolfObjectInfo.GetAllObjectLimits());
    AddFactionObjectInfo(GilneasObjectInfo.GetAllObjectLimits());
    AddFactionObjectInfo(IllidariObjectInfo.GetAllObjectLimits());
    AddFactionObjectInfo(IronforgeObjectInfo.GetAllObjectLimits());
    AddFactionObjectInfo(KultirasObjectInfo.GetAllObjectLimits());
    AddFactionObjectInfo(LegionObjectInfo.GetAllObjectLimits());
    AddFactionObjectInfo(LordaeronObjectInfo.GetAllObjectLimits());
    AddFactionObjectInfo(NazjatarObjectInfo.GetAllObjectLimits());
    AddFactionObjectInfo(QuelthalasObjectInfo.GetAllObjectLimits());
    AddFactionObjectInfo(ScarletCrusadeObjectInfo.GetAllObjectLimits());
    AddFactionObjectInfo(ScourgeObjectInfo.GetAllObjectLimits());
    AddFactionObjectInfo(SentinelsObjectInfo.GetAllObjectLimits());
    AddFactionObjectInfo(SkywallObjectInfo.GetAllObjectLimits());
    AddFactionObjectInfo(StormwindObjectInfo.GetAllObjectLimits());
    AddFactionObjectInfo(SunfuryObjectInfo.GetAllObjectLimits());
    AddFactionObjectInfo(WarsongObjectInfo.GetAllObjectLimits());
    AddFactionObjectInfo(ZandalarObjectInfo.GetAllObjectLimits());
  }

  /// <summary>
  /// Gets all object information from every single faction.
  /// </summary>
  public List<ObjectInfo> GetAllObjectInfo() => _all;

  /// <summary>
  /// Gets the object information for a specific object type.
  /// </summary>
  public bool TryGetObjectInfo(int objectTypeId, [NotNullWhen(true)] out ObjectInfo? objectLimit)
  {
    objectLimit = _byObjectId.TryGetValue(objectTypeId.IdToFourCc(), out var value) ? value : null;
    return value != null;
  }

  private void AddFactionObjectInfo(IEnumerable<ObjectInfo> factionObjectLimits)
  {
    foreach (var (objectTypeId, objectInfo) in factionObjectLimits)
    {
      if (!_byObjectId.ContainsKey(objectTypeId))
      {
        _byObjectId.Add(objectTypeId, objectInfo);
        _all.Add(objectInfo);
      }
    }
  }
}
