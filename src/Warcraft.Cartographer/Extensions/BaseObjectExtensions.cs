using War3Api.Object;
using War3Net.Common.Extensions;

namespace Warcraft.Cartographer.Extensions;

public static class BaseObjectExtensions
{
  extension(BaseObject baseObject)
  {
    public int GetId()
    {
      return baseObject.NewId != 0 ? baseObject.NewId : baseObject.OldId;
    }

    public string GetReadableId()
    {
      return baseObject.GetId().ToRawcode();
    }
  }
}
