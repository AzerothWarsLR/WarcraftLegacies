using DesyncSafeAnalyzer.Tools;
using static War3Api.Common;

namespace MacroTools.Extensions
{
  /// <summary>
  /// Provides a useful set of extension methods for native Warcraft 3 framehandle objects.
  /// </summary>
  public static class FrameExtensions
  {
    /// <summary>
    /// Returns the framehandle's width.
    /// </summary>
    public static float GetWidth(this framehandle frameHandle) => BlzFrameGetWidth(frameHandle);

    /// <summary>
    /// Returns the framehandle's height.
    /// </summary>
    public static float GetHeight(this framehandle frameHandle) => BlzFrameGetHeight(frameHandle);

    /// <summary>
    /// Determines whether or not the frame is visible.
    /// </summary>
    [DesyncSafe]
    public static void SetVisible(this framehandle frameHandle, bool visible) => BlzFrameSetVisible(frameHandle, visible);
  }
}