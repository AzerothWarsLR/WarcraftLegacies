using AzerothWarsCSharp.MacroTools.Libraries;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup
{
  /// <summary>
  /// Hides all pathing blockers on the map.
  /// </summary>
  public static class BlockerSetup
  {
    public static void Setup()
    {
      var pathingBlockers = new[]
      {
        FourCC("YTlb"),
        FourCC("YTlc"),
        FourCC("B009"),
        FourCC("B00A"),
        FourCC("YTab"),
        FourCC("YTac"),
        FourCC("YTfb"),
        FourCC("YTfc"),
        FourCC("YTpb"),
        FourCC("YTpc"),
        FourCC("B011"),
        FourCC("OTip")
      };

      EnumDestructablesInRect(WCSharp.Shared.Data.Rectangle.WorldBounds.Rect, null, () =>
      {
        foreach (var pathingBlocker in pathingBlockers)
        {
          if (GetDestructableTypeId(GetEnumDestructable()) == pathingBlocker) RemoveDestructable(GetEnumDestructable());
        }
      });
    }
  }
}