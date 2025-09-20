using War3Net.Build.Object;

namespace Launcher.Extensions;

public static class UnitObjectDataExtensions
{
  /// <summary>
  /// War3Net does not correctly populate the <see cref="SimpleObjectModification.Unk"/> property for
  /// <see cref="SimpleObjectModification"/>s, which causes a map crash. Use this to fix those missing values.
  /// </summary>
  public static void FixUnkValues(this UnitObjectData unitObjectData)
  {
    foreach (var simpleObjectModification in unitObjectData.BaseUnits)
    {
      FixUnkValue(simpleObjectModification);
    }

    foreach (var simpleObjectModification in unitObjectData.NewUnits)
    {
      FixUnkValue(simpleObjectModification);
    }
  }

  private static void FixUnkValue(SimpleObjectModification simpleObjectModification) =>
    simpleObjectModification.Unk.Add(0);
}
