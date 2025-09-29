using War3Api.Object;
using War3Net.Common.Extensions;

namespace Launcher.Extensions;

public static class BaseObjectExtensions
{
  public static int GetId(this BaseObject baseObject) => baseObject.NewId != 0 ? baseObject.NewId : baseObject.OldId;

  public static string GetReadableId(this BaseObject baseObject) =>
    baseObject.NewId != 0 ? baseObject.NewId.ToRawcode() : baseObject.OldId.ToRawcode();
}
