using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Setup;

/// <summary>
/// Hides all pathing blockers on the map.
/// </summary>
public static class BlockerSetup
{
  /// <summary>
  /// Hides all pathing blockers on the map.
  /// </summary>
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
    };

    Rectangle.WorldBounds.Rect.EnumerateDestructables(null, () =>
    {
      foreach (var pathingBlocker in pathingBlockers)
      {
        var destructable = GetEnumDestructable();
        if (destructable.Type == pathingBlocker)
        {
          destructable.SetVisibility(false);
        }
      }
    });
  }
}
