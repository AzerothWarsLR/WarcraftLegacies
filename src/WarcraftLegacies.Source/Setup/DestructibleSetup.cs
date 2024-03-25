using MacroTools;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Setup
{
  /// <summary>
  /// Initializes game state as it relates to destructables.
  /// </summary>
  public static class DestructibleSetup
  {
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      var thandolSpan = preplacedUnitSystem.GetDestructable(FourCC("LT08"), new Point(15695, 457));
      SetDestructableInvulnerable(thandolSpan, true);
      //KillDestructable(thandolSpan);
    }
  }
}