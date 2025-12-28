

// ReSharper disable once CheckNamespace
namespace War3Net.Build.Object;

public static class ObjectModificationExtensions
{
  public static int GetId(this SimpleObjectModification objectModification)
  {
    return objectModification.NewId != 0 ? objectModification.NewId : objectModification.OldId;
  }

  public static int GetId(this VariationObjectModification objectModification)
  {
    return objectModification.NewId != 0 ? objectModification.NewId : objectModification.OldId;
  }

  public static int GetId(this LevelObjectModification objectModification)
  {
    return objectModification.NewId != 0 ? objectModification.NewId : objectModification.OldId;
  }
}
