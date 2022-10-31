using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.MacroTools.Extensions
{
  /// <summary>
  /// Provides a helpful set of extension methods for <see cref="Rectangle"/>s.
  /// </summary>
  public static class RectangleExtensions
  {
    /// <summary>
    /// Causes the provided sound to be played as ambience whenever a player has their camera near this <see cref="Rectangle"/>.
    /// </summary>
    public static void AddSound(this Rectangle region, sound soundHandle)
    {
      var width = GetRectMaxX(region.Rect) - GetRectMinX(region.Rect);
      var height = GetRectMaxY(region.Rect) - GetRectMinY(region.Rect);
      SetSoundPosition(soundHandle, GetRectCenterX(region.Rect), GetRectCenterY(region.Rect), 0);
      RegisterStackedSound(soundHandle, true, width, height);
    }
  }
}