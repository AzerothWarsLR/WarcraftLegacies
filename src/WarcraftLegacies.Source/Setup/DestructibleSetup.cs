using MacroTools.PreplacedWidgets;

namespace WarcraftLegacies.Source.Setup;

/// <summary>
/// Initializes game state as it relates to destructables.
/// </summary>
public static class DestructibleSetup
{
  public static void Setup()
  {
    var thandolSpan = AllPreplacedWidgets.Destructables.GetClosest(FourCC("LT08"), 15695, 457);
    thandolSpan.IsInvulnerable = true;
    //thandolSpan.Kill();
  }
}
