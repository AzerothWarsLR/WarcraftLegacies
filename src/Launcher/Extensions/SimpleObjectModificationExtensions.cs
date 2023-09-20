#nullable enable
using System.Linq;
using War3Net.Build.Object;

namespace Launcher.Extensions
{
  public static class SimpleObjectModificationExtensions
  {
    public static bool TryGetDataModification(this SimpleObjectModification simpleObjectModification,
      int key, out SimpleObjectDataModification? dataModification)
    {
      dataModification = simpleObjectModification.Modifications.FirstOrDefault(x => x.Id == key);
      return dataModification != null;
    }
  }
}