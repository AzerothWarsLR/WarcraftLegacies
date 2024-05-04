using War3Api.Object;

namespace Launcher.Extensions
{
  public static class UnitExtensions
  {
    public static string GetExtendedTooltipSafe(this Unit unit)
    {
      try
      {
        return unit.TextTooltipExtended;
      }
      catch
      {
        return "";
      }
    }
  }
}