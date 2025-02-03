using MacroTools.Shared.Extensions;
using War3Api.Object;

namespace Launcher.Extensions
{
  public static class BaseObjectExtensions
  {
    public static string GetReadableId(this BaseObject baseObject) =>
      baseObject.NewId != 0 ? baseObject.NewId.IdToFourCc() : baseObject.OldId.IdToFourCc();
  }
}