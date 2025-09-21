using MacroTools.Systems;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Setup;

/// <summary>
/// Initializes game state as it relates to destructables.
/// </summary>
public static class DestructibleSetup
{
  public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
  {
    var thandolSpan = preplacedUnitSystem.GetDestructable(FourCC("LT08"), new Point(15695, 457));
    thandolSpan.IsInvulnerable = true;
    //thandolSpan.Kill();
  }
}
