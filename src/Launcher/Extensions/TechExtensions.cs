using War3Api.Object;

namespace Launcher.Extensions
{
  public static class TechExtensions
  {
    public static bool IsUpgradeSafe(this Tech tech)
    {
      try
      {
        _ = tech.AsUpgrade;
        return true;
      }
      catch
      {
        return false;
      }
    }
    
    public static string GetTextNameSafe(this Upgrade upgrade)
    {
      try
      {
        return upgrade.TextName[0];
      }
      catch
      {
        try
        {
          return upgrade.TextName[1];
        }
        catch
        {
          return "";
        }
      }
    }

    public static int GetPrioritySafe(this Upgrade upgrade)
    {
      try
      {
        var (x, y) = (upgrade.ArtButtonPositionX, upgrade.ArtButtonPositionY);
        return x - y * 10;
      }
      catch
      {
        return 0;
      }
    }
  }
}