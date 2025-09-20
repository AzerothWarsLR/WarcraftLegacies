using War3Api.Object;

namespace Launcher.Extensions;

public static class ItemExtensions
{
  public static int GetPriority(this Item item)
  {
    try
    {
      var (x, y) = (item.ArtButtonPositionX, item.ArtButtonPositionY);
      return x - y * 10;
    }
    catch
    {
      return 0;
    }
  }
}
