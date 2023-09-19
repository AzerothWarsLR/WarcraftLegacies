#nullable enable
using System.Linq;
using War3Net.Build.Object;

namespace Launcher.Extensions
{
  public static class SimpleObjectModificationExtensions
  {
    public static SimpleObjectDataModification? GetDataModification(this SimpleObjectModification simpleDataModification,
      int key) => simpleDataModification.Modifications.FirstOrDefault(x => x.Id == key);
  }
}