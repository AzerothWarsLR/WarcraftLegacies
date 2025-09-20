using MacroTools.Extensions;
using MacroTools.Systems;

namespace WarcraftLegacies.Source.Setup;

/// <summary>
/// Responsible for setting up capturable units via <see cref="UnitExtensions.MakeCapturable"/>.
/// </summary>
public static class CapturableUnitSetup
{
  /// <summary>
  /// Sets up <see cref="CapturableUnitSetup"/>.
  /// </summary>
  public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
  {
    foreach (var fountainOfHealth in preplacedUnitSystem.GetUnits(FourCC("nfoh")))
    {
      fountainOfHealth.MakeCapturable();
    }

    foreach (var tradingPost in preplacedUnitSystem.GetUnits(FourCC("h014")))
    {
      tradingPost.MakeCapturable();
    }
  }
}
