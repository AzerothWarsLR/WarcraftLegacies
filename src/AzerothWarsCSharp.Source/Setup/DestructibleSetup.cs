using AzerothWarsCSharp.MacroTools;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup
{
  /// <summary>
  /// Initializes game state as it relates to destructables.
  /// </summary>
  public static class DestructibleSetup
  {
    public static void Setup()
    {
      EnumDestructablesInRect(Regions.AhnqirajInstance.Rect, null, () =>
      {
        SetDestructableAnimationSpeed(GetEnumDestructable(), 0);
      });

      var thandolSpan = PreplacedUnitSystem.GetDestructable(FourCC("LT08"), new Point(15695, 457));
      SetDestructableInvulnerable(thandolSpan, true);
    }
  }
}