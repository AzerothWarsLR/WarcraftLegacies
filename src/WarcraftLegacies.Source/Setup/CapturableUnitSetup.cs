using MacroTools.Extensions;
using MacroTools.PreplacedWidgets;

namespace WarcraftLegacies.Source.Setup;

/// <summary>
/// Responsible for setting up capturable units via <see cref="UnitExtensions.MakeCapturable"/>.
/// </summary>
public static class CapturableUnitSetup
{
  /// <summary>
  /// Sets up <see cref="CapturableUnitSetup"/>.
  /// </summary>
  public static void Setup()
  {
    foreach (var fountainOfHealth in AllPreplacedWidgets.Units.GetAll(UNIT_NFOH_FOUNTAIN_OF_HEALTH))
    {
      fountainOfHealth.MakeCapturable();
    }

    foreach (var tradingPost in AllPreplacedWidgets.Units.GetAll(UNIT_H014_TRADING_POST_SEA))
    {
      tradingPost.MakeCapturable();
    }
  }
}
