using MacroTools;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup
{
  /// <summary>
  /// Initializes game state as it relates to destructables.
  /// </summary>
  public static class DestructibleSetup
  {
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      EnumDestructablesInRect(Regions.AhnqirajInstance.Rect, null, () =>
      {
        SetDestructableAnimationSpeed(GetEnumDestructable(), 0);
      });

      var thandolSpan = preplacedUnitSystem.GetDestructable(FourCC("LT08"), new Point(15695, 457));
      SetDestructableInvulnerable(thandolSpan, true);
    }
  }
}