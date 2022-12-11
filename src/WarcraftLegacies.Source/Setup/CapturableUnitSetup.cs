using MacroTools;
using MacroTools.Extensions;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup
{
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
        fountainOfHealth.MakeCapturable();
      foreach (var controlNexus in preplacedUnitSystem.GetUnits(Constants.UNIT_N05J_DARK_PORTAL_AURA_CONTROL_NEXUS))
        controlNexus.MakeCapturable();
    }
  }
}