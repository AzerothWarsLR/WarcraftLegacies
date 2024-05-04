using War3Api.Object;

namespace Launcher.Extensions
{
  public static class ItemExtensions
  {
    public static string GetTextNameSafe(this Item item)
    {
      try
      {
        return item.TextName;
      }
      catch
      {
        return "";
      }
    }

    public static int GetPrioritySafe(this Item item)
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
}